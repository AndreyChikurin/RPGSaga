namespace RpgSaga.Loggers
{
    using RpgSaga.Players;

    public interface ILogger
    {
        public void EffectLog(Player player, string message);

        public void FightLog(Player attacker, Player defender);

        public void SkillLog(Player soursePlayer, Player targetPlayer, string skillName);

        public void WinnerLog(Player player);
    }
}