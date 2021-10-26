namespace RpgSaga.Skills
{
    using System.Linq;
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Players;
    using RpgSaga.Rounds;

    public class FireArrows : ISkill
    {
        private ILogger _skillLogger;

        public FireArrows(ILogger skillLogger)
        {
            _skillLogger = skillLogger;
        }

        public void SkillAction(Player soursePlayer, Player targetPlayer)
        {
            if (targetPlayer.Effects.OfType<Burning>().Any())
            {
                Hit.Punch(soursePlayer, targetPlayer, _skillLogger);
            }
            else
            {
                targetPlayer.Effects.Add(new Burning(_skillLogger));
                _skillLogger.SkillLog(soursePlayer, targetPlayer, "FireArrows");
            }
        }
    }
}
