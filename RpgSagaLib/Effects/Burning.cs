namespace RpgSagaLib.Effects
{
    using RpgSagaLib.Interfaces;
    using RpgSagaLib.Loggers;
    using RpgSagaLib.Players;

    public class Burning : IEffect
    {
        private ILogger _effectLogger;

        public Burning(ILogger effectLogger)
        {
            _effectLogger = effectLogger;
            Duration = 1;
        }

        public int Duration { get; private set; }

        public void EffectAction(Player player)
        {
            player.Hp -= 2;

            _effectLogger.EffectLog(player, "Burning and deal 2 damage");
        }
    }
}
