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

    public class Game
    {
        private int _numberOfPlayerTypes;

        private int _numberOfPlayers;

        private ILogger _logger;

        private List<Player> _players;

        public Game()
        {
            ErrorMessage = new List<string>();
            GameHaveCompleted = false;
            _players = new List<Player>();
            _numberOfPlayerTypes = Assembly.GetAssembly(typeof(Player)).GetTypes().Where(type => type.IsSubclassOf(typeof(Player))).Count();
        }

        public List<string> ErrorMessage { get; private set; }

        public bool GameHaveCompleted { get; private set; }

        public bool Start(int loggerType, int playersNumber)
        {
            if (ChoosingLogger(loggerType) && ChoosingNumberOfPlayers(playersNumber))
            {
                Filling();
                Tournament();
                CurrentWinner();
                GameHaveCompleted = true;
                return true;
            }

            return false;
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

        private bool ChoosingLogger(int loggerType)
        {
            try
            {
                LogType log = (LogType)loggerType;

                if (log == LogType.LogFile)
                {
                    _logger = new LoggerForFile(@"Logs");
                }

                if (log == LogType.LogConsole)
                {
                    _logger = new LoggerForConsole();
                }
                else
                {
                    string errorMessage = "Please, try again.(incorrect log type)";
                    ErrorMessage.Add(errorMessage);

                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Add(ex.Message);
                return false;
            }

            return true;
        }

        private bool ChoosingNumberOfPlayers(int playersNumber)
        {
            try
            {
                if (playersNumber > 0 && playersNumber % 2 == 0)
                {
                    _numberOfPlayers = playersNumber;
                }
                else
                {
                    _numberOfPlayers = 0;
                    string errorMessage = "Please, try again.(incorrect players number)";
                    ErrorMessage.Add(errorMessage);

                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Add(ex.Message);
                return false;
            }

            return true;
        }
    }
}
