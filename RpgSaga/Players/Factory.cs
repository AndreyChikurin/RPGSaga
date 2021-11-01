namespace RpgSaga.Players
{
    using System.Collections.Generic;
    using RpgSaga.Consts;
    using RpgSaga.Data;
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Skills;

    public class Factory
    {
        private ILogger _logger;

        public Factory(ILogger logger)
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
    }
}
