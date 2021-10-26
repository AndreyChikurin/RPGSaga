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

        public Game(LogType log, int numberOfPlayers)
        {
            _logger = log == LogType.LogConsole ? new LoggerForConsole() : new LoggerForFile(@"Logs");
            _numberOfPlayers = numberOfPlayers;
            _players = new List<Player>();
            _numberOfPlayerTypes = Assembly.GetAssembly(typeof(Player)).GetTypes().Where(type => type.IsSubclassOf(typeof(Player))).Count();
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
            }
        }
    }
}
