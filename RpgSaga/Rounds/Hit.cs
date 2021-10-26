namespace RpgSaga.Rounds
{
    using RpgSaga.Loggers;
    using RpgSaga.Players;

    public static class Hit
    {
        public static void Punch(Player attacker, Player defender, ILogger logger)
        {
            defender.Hp -= attacker.Strength;
            logger.FightLog(attacker, defender);
        }
    }
}
