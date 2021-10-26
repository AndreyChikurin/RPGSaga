namespace RpgSaga.Skills
{
    using System;
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Players;

    public class MortalStrike : ISkill
    {
        private ILogger _skillLogger;

        private decimal damageCoefficient = 1.3m;

        public MortalStrike(ILogger skillLogger)
        {
            _skillLogger = skillLogger;
            SkillCanBeUsed = true;
        }

        public bool SkillCanBeUsed { get; set; }

        public void SkillAction(Player soursePlayer, Player targetPlayer)
        {
            int damage = (int)Math.Round(soursePlayer.Strength * damageCoefficient);
            targetPlayer.Hp -= damage;

            _skillLogger.SkillLog(soursePlayer, targetPlayer, $"MortalStrike and deals {damage}");
        }
    }
}
