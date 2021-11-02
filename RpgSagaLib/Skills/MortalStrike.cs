namespace RpgSagaLib.Skills
{
    using System;
    using RpgSagaLib.Interfaces;
    using RpgSagaLib.Loggers;
    using RpgSagaLib.Players;

    public class MortalStrike : ISkill
    {
        private ILogger _skillLogger;

        private decimal damageCoefficient = 1.3m;

        public MortalStrike(ILogger skillLogger)
        {
            _skillLogger = skillLogger;
        }

        public bool SkillCanBeUsed { get => true; }

        public void SkillAction(Player soursePlayer, Player targetPlayer)
        {
            int damage = (int)Math.Round(soursePlayer.Strength * damageCoefficient);
            targetPlayer.Hp -= damage;

            _skillLogger.SkillLog(soursePlayer, targetPlayer, $"MortalStrike and deals {damage}");
        }
    }
}
