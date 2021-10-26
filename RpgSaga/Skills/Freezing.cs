namespace RpgSaga.Skills
{
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Players;

    public class Freezing : ISkill
    {
        private ILogger _skillLogger;

        public Freezing(ILogger skillLogger)
        {
            _skillLogger = skillLogger;
            SkillCanBeUsed = true;
        }

        public bool SkillCanBeUsed { get; set; }

        public void SkillAction(Player soursePlayer, Player targetPlayer)
        {
            targetPlayer.Effects.Add(new SkipMove(_skillLogger, 1));

            _skillLogger.SkillLog(soursePlayer, targetPlayer, "Freezing");
        }
    }
}
