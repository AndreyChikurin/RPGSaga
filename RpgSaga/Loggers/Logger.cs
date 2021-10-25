namespace RpgSaga.Loggers
{
    using RpgSaga.Players;

    public abstract class Logger : ILogger
    {
        public virtual void EffectLog(Player player, string effectName)
        {
        }

        public virtual void FightLog(Player attacker, Player defender)
        {
        }

        public virtual void SkillLog(Player soursePlayer, Player targetPlayer, string skillName)
        {
        }

        public virtual void WinnerLog(Player winner)
        {
        }
    }
}
