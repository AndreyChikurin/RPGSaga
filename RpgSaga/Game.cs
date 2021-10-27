namespace RpgSaga
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using RpgSaga.Consts;
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Players;
    using RpgSaga.Rounds;
    using RpgSaga.Skills;
    using RpgSaga.User;

    public class Game
    {
        private int _numberOfPlayerTypes;

        private int _numberOfPlayers;

        private ILogger _logger;

        private List<Player> _players;

        private UserActions _userActions;

        public Game()
        {
            _userActions = new UserActions();
            _players = new List<Player>();
            _numberOfPlayerTypes = Assembly.GetAssembly(typeof(Player)).GetTypes().Where(type => type.IsSubclassOf(typeof(Player))).Count();
        }

        public void Start()
        {
            ChoosingLogger();
            ChoosingNumberOfPlayers();
            Filling();
            Tournament();
            CurrentWinner();
        }

        private void Filling()
        {
            Random random = new Random();

            _players = new List<Player>(_numberOfPlayers);

            for (int i = 0; i < _numberOfPlayers; i++)
            {
                switch (random.Next(0, _numberOfPlayerTypes))
                {
                    case 0:
                        {
                            _players.Add(new Hunter(
                                random.Next(4, 7),
                                random.Next(50, 70),
                                PlayerNames.Hunter[random.Next(0, PlayerNames.Hunter.Length)] + $"{i + 1}",
                                new List<ISkill> { new FireArrows(_logger) }));
                            break;
                        }

                    case 1:
                        {
                            _players.Add(new Warrior(
                                random.Next(4, 7),
                                random.Next(50, 70),
                                PlayerNames.Warrior[random.Next(0, PlayerNames.Warrior.Length)] + $"{i + 1}",
                                new List<ISkill> { new MortalStrike(_logger) }));
                            break;
                        }

                    case 2:
                        {
                            _players.Add(new Mage(
                                random.Next(4, 7),
                                random.Next(50, 70),
                                PlayerNames.Mage[random.Next(0, PlayerNames.Mage.Length)] + $"{i + 1}",
                                new List<ISkill> { new Freezing(_logger) }));
                            break;
                        }
                }

                Console.WriteLine(_players[i].Name + " " + _players[i].Hp);
            }
        }

        private void Tournament()
        {
            while (_players.Count > 1)
            {
                Round currentRound = new Round(_players, _logger);
                currentRound.Start();
            }
        }

        private void CurrentWinner()
        {
            _logger.WinnerLog(_players[0]);
        }

        private void ChoosingLogger()
        {
            while (_logger is null)
            {
                try
                {
                    Console.Write("Enter 1 to write logs to a file or 0 to write logs to the console: ");
                    LogType log = _userActions.InputForChoosingLogger();

                    if (log == LogType.LogFile)
                    {
                        Console.Write("Enter the path where the file will be stored: ");
                        string path = _userActions.InputForTheFilePath();
                        _logger = new LoggerForFile(@$"{path}");
                    }

                    if (log == LogType.LogConsole)
                    {
                        _logger = new LoggerForConsole();
                    }

                    if (log != LogType.LogFile && log != LogType.LogConsole)
                    {
                        Console.WriteLine("Please, try again.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void ChoosingNumberOfPlayers()
        {
            while (_numberOfPlayers == 0)
            {
                try
                {
                    Console.Write("Please select an even number of players: ");
                    _numberOfPlayers = _userActions.InputForChoosingNumberOfPlayers();

                    if (_numberOfPlayers <= 0 || _numberOfPlayers % 2 == 1)
                    {
                        _numberOfPlayers = 0;
                        Console.WriteLine("Please, try again.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
