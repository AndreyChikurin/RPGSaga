namespace RpgSaga
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using RpgSaga.Consts;
    using RpgSaga.Data;
    using RpgSaga.Deserialize;
    using RpgSaga.Loggers;
    using RpgSaga.Players;
    using RpgSaga.Rounds;

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

        public void Start(string loggerType, string playersNumber, string playersGenerationType)
        {
            _errorMessages.Clear();

            if (ChoosingLogger(loggerType))
            {
                PlayersGeneration(playersNumber, playersGenerationType);
            }
            else
            {
                PlayersGenerationErrors(playersNumber, playersGenerationType);
            }
        }

        private void PlayersGenerationErrors(string playersNumber, string playersGenerationType)
        {
            if (playersNumber == null)
            {
                PlayerCreatingFromJson(_logger, playersGenerationType);
            }
            else
            {
                ChoosingNumberOfPlayers(playersNumber);
            }
        }

        private void PlayersGeneration(string playersNumber, string playersGenerationType)
        {
            if (!PlayerCreatingFromJson(_logger, playersGenerationType))
            {
                if (ChoosingNumberOfPlayers(playersNumber))
                {
                    Filling();
                }
            }

            if (_players.Count > 1)
            {
                Tournament();
                CurrentWinner();
                GameHaveCompleted = true;
            }
        }

        private void Filling()
        {
            PlayersFactory playersFactory = new PlayersFactory(_logger);

            _players = new List<Player>(_numberOfPlayers);

            for (int i = 0; i < _numberOfPlayers; i++)
            {
                _players.Add(playersFactory.CreatePlayer(_numberOfPlayerTypes));

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
            if (playersNumber == null)
            {
                return false;
            }

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
            errorMessage = "Incorrect players number";
            _errorMessages.Add(errorMessage);

            return false;
        }

        private bool PlayerCreatingFromJson(ILogger logger, string generationOfPlayers)
        {
            bool success = int.TryParse(generationOfPlayers, out int number);
            string errorMessage;

            if (!success)
            {
                errorMessage = "GenerationOfPlayers was not a number";
                _errorMessages.Add(errorMessage);

                return false;
            }

            GenerationOfPlayers generation = (GenerationOfPlayers)number;

            PlayersFactory factory = new PlayersFactory(logger);
            List<PlayerDto> playerModels = new DeserializePlayer().DeserializePlayerFromJson(_errorMessages);

            if (generation == GenerationOfPlayers.ByFile)
            {
                if (playerModels is null)
                {
                    errorMessage = "Player creation from JSON file is failed";
                    _errorMessages.Add(errorMessage);
                    return false;
                }

                foreach (PlayerDto model in playerModels)
                {
                    var player = factory.CreatePlayer(model);
                    if (!(player is null))
                    {
                        _players.Add(player);
                    }
                }

                return true;
            }

            if (generation != GenerationOfPlayers.ByRandom)
            {
                errorMessage = "Incorrect generation of players number";
                _errorMessages.Add(errorMessage);
            }

            return false;
        }
    }
}
