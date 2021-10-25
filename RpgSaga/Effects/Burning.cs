namespace RpgSaga.Effects
{
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Players;

    public class Burning : IEffect
    {
        private ILogger _effectLogger;

        public Burning(ILogger effectLogger)
        {
            _effectLogger = effectLogger;
        }

        public int Duration { get => Duration; set => Duration = 1; }

        public void EffectAction(Player player)
        {
            player.Hp -= 2;

            _effectLogger.EffectLog(player, "Burning and deal 2 damage");
        }
    }
}
