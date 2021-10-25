﻿namespace RpgSaga
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
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

        public Game(LogType log, int numberOfPlayers)
        {
            _logger = log == LogType.LogConsole ? new LoggerForConsole() : new LoggerForFile(@"Logs");
            _numberOfPlayers = numberOfPlayers;
            Players = new List<Player>();
            _numberOfPlayerTypes = Assembly.GetAssembly(typeof(Player)).GetTypes().Where(type => type.IsSubclassOf(typeof(Player))).Count();
        }

        public enum LogType
        {
            LogConsole,
            LogFile,
        }

        private List<Player> Players { get; set; }

        private Round CurrentRound { get; set; }

        public void Filling()
        {
            Random random = new Random();

            Players = new List<Player>(_numberOfPlayers);

            for (int i = 0; i < _numberOfPlayers - 1; i++)
            {
                switch (random.Next(0, _numberOfPlayerTypes))
                {
                    case 0:
                        {
                            Players.Add(new Hunter(
                                random.Next(50, 70),
                                random.Next(4, 7),
                                PlayerNames.Hunter[random.Next(0, PlayerNames.Hunter.Length)],
                                new List<ISkill> { new FireArrows(_logger) }));
                            break;
                        }

                    case 1:
                        {
                            Players.Add(new Warrior(
                                random.Next(50, 70),
                                random.Next(4, 7),
                                PlayerNames.Warrior[random.Next(0, PlayerNames.Warrior.Length)],
                                new List<ISkill> { new MortalStrike(_logger) }));
                            break;
                        }

                    case 2:
                        {
                            Players.Add(new Mage(
                                random.Next(50, 70),
                                random.Next(4, 7),
                                PlayerNames.Mage[random.Next(0, PlayerNames.Mage.Length)],
                                new List<ISkill> { new Freezing(_logger) }));
                            break;
                        }
                }
            }
        }

        public void Tournament()
        {
            while (Players.Count > 1)
            {
                CurrentRound = new Round(Players);
                CurrentRound.Start();
            }
        }

        public void CurrentWinner()
        {
            _logger.WinnerLog(Players[0]);
        }

        public void Start()
        {
            Filling();
            Tournament();
            CurrentWinner();
        }
    }
}
