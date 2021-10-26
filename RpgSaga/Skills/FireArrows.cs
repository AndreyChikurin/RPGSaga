namespace RpgSaga.Skills
{
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Players;

    public class FireArrows : ISkill
    {
        private ILogger _skillLogger;

        public FireArrows(ILogger skillLogger)
        {
            _skillLogger = skillLogger;
            SkillCanBeUsed = true;
        }

        public bool SkillCanBeUsed { get; private set; }

        public void SkillAction(Player soursePlayer, Player targetPlayer)
        {
            targetPlayer.Effects.Add(new Burning(_skillLogger));
            _skillLogger.SkillLog(soursePlayer, targetPlayer, "FireArrows");
            SkillCanBeUsed = false;
        }
    }
}
