namespace RpgSaga
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;
    using RpgSaga.Consts;
    using RpgSaga.Data;
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

        public void Start(string loggerType, string playersNumber, string generationOfPlayers)
        {
            _errorMessages.Clear();

            if (ChoosingLogger(loggerType))
            {
                PlayersGeneration(playersNumber, generationOfPlayers);
            }
            else
            {
                PlayersGenerationErrors(playersNumber, generationOfPlayers);
            }
        }

        private void PlayersGenerationErrors(string playersNumber, string generationOfPlayers)
        {
            if (playersNumber == null)
            {
                PlayerCreatingFromJson(_logger, generationOfPlayers);
            }
            else
            {
                ChoosingNumberOfPlayers(playersNumber);
            }
        }

        private void PlayersGeneration(string playersNumber, string generationOfPlayers)
        {
            if (PlayerCreatingFromJson(_logger, generationOfPlayers))
            {
                Tournament();
                CurrentWinner();
                GameHaveCompleted = true;
            }
            else if (ChoosingNumberOfPlayers(playersNumber))
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

            Factory factory = new Factory(logger);
            List<PlayerDto> playerModels = DeserializePlayerFromJson();

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

        private List<PlayerDto> DeserializePlayerFromJson()
        {
            string directory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;

            string path = @$"{directory}/JsonForPlayer/Players.json";

            string data = File.ReadAllText(path);

            string errorMessage;

            List<PlayerDto> models = new List<PlayerDto>();
            try
            {
                models = JsonConvert.DeserializeObject<List<PlayerDto>>(data);
                if (models.Count < 2 || models.Count % 2 != 0)
                {
                    throw new Exception();
                }

                _numberOfPlayers = models.Count;

                for (int i = 0; i < models.Count; i++)
                {
                    if (models[i].MaxHp < 1
                        || models[i].Strenght < 1
                        || string.IsNullOrWhiteSpace(models[i].Name))
                    {
                        throw new Exception();
                    }
                }
            }
            catch (JsonReaderException)
            {
                errorMessage = "Error reading Json";
                _errorMessages.Add(errorMessage);
                return null;
            }
            catch (JsonSerializationException)
            {
                errorMessage = "Json is incorrect, check data";
                _errorMessages.Add(errorMessage);
                return null;
            }
            catch (Exception)
            {
                errorMessage = "Data is incorrect format. Model count must be great or equal 2. Health and strenght must be > 0";
                _errorMessages.Add(errorMessage);
                return null;
            }

            return models;
        }
    }
}
