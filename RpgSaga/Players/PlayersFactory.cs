﻿namespace RpgSaga.Players
{
    using System;
    using System.Collections.Generic;
    using RpgSaga.Consts;
    using RpgSaga.Data;
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Rounds;
    using RpgSaga.Skills;

    public class PlayersFactory
    {
        private ILogger _logger;

        public PlayersFactory(ILogger logger)
        {
            _logger = logger;
        }

        public Player CreatePlayer(PlayerDto model)
        {
            switch (model.PlayerClass)
            {
                case PlayerClasses.Mage:
                    return new Mage(
                        model.Strenght,
                        model.MaxHp,
                        model.Name,
                        new List<ISkill> { new Freezing(_logger) });
                case PlayerClasses.Warrior:
                    return new Warrior(
                        model.Strenght,
                        model.MaxHp,
                        model.Name,
                        new List<ISkill> { new MortalStrike(_logger) });
                case PlayerClasses.Hunter:
                    return new Hunter(
                        model.Strenght,
                        model.MaxHp,
                        model.Name,
                        new List<ISkill> { new FireArrows(_logger) });
                default:
                    return null;
            }
        }

        public Player CreatePlayer(int numberOfPlayersTypes)
        {
            Random random = new Random();

            switch ((PlayerClasses)random.Next(0, numberOfPlayersTypes))
            {
                case PlayerClasses.Hunter:
                    {
                        return new Hunter(
                            random.Next(4, 7),
                            random.Next(50, 70),
                            PlayerNames.Hunter[random.Next(0, PlayerNames.Hunter.Length)],
                            new List<ISkill> { new FireArrows(_logger) });
                    }

                case PlayerClasses.Warrior:
                    {
                        return new Warrior(
                            random.Next(4, 7),
                            random.Next(50, 70),
                            PlayerNames.Warrior[random.Next(0, PlayerNames.Warrior.Length)],
                            new List<ISkill> { new MortalStrike(_logger) });
                    }

                case PlayerClasses.Mage:
                    {
                        return new Mage(
                            random.Next(4, 7),
                            random.Next(50, 70),
                            PlayerNames.Mage[random.Next(0, PlayerNames.Mage.Length)],
                            new List<ISkill> { new Freezing(_logger) });
                    }
            }

            return null;
        }
    }
}
