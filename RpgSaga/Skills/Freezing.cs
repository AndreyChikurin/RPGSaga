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
        }

        public void SkillAction(Player soursePlayer, Player targetPlayer)
        {
            targetPlayer.Effects.Add(new SkipMove(_skillLogger));

            _skillLogger.SkillLog(soursePlayer, targetPlayer, "Freezing");
        }
    }
}
