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

        private List<string> _errorMessages;

        public Game()
        {
            _errorMessages = new List<string>();
            GameHaveCompleted = false;
            _players = new List<Player>();
            _numberOfPlayerTypes = Assembly.GetAssembly(typeof(Player)).GetTypes().Where(type => type.IsSubclassOf(typeof(Player))).Count();
        }

        public IEnumerable<string> ErrorMessages => _errorMessages;

        public bool GameHaveCompleted { get; private set; }

        public void Start(string loggerType, string playersNumber)
        {
            _errorMessages.Clear();

            if (ChoosingLogger(loggerType) & ChoosingNumberOfPlayers(playersNumber))
            {
                Filling();
                Tournament();
                CurrentWinner();
                GameHaveCompleted = true;
            }
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

        private bool ChoosingLogger(string loggerType)
        {
            bool success = int.TryParse(loggerType, out int number);
            string errorMessage;

            if (!success)
            {
                errorMessage = "Log type was not a number";
                _errorMessages.Add(errorMessage);

                return false;
            }

            LogType log = (LogType)number;

            if (log == LogType.LogFile)
            {
                _logger = new LoggerForFile(@"Logs");
                return true;
            }

            if (log == LogType.LogConsole)
            {
                _logger = new LoggerForConsole();
                return true;
            }

            errorMessage = "Incorrect log type";
            _errorMessages.Add(errorMessage);

            return false;
        }

        private bool ChoosingNumberOfPlayers(string playersNumber)
        {
            bool success = int.TryParse(playersNumber, out int number);
            string errorMessage;

            if (!success)
            {
                errorMessage = "Players number was not a number";
                _errorMessages.Add(errorMessage);

                return false;
            }

            if (number > 0 && number % 2 == 0)
            {
                _numberOfPlayers = number;
                return true;
            }

            _numberOfPlayers = 0;
            errorMessage = "incorrect players number";
            _errorMessages.Add(errorMessage);

            return false;
        }
    }
}
