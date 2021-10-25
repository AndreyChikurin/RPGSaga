namespace RpgSaga.Effects
{
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Players;

    public class SkipMove : IEffect
    {
        private ILogger _effectLogger;

        public SkipMove(ILogger effectLogger)
        {
            _effectLogger = effectLogger;
        }

        public int Duration { get => Duration; set => Duration = 1; }

        public void EffectAction(Player player)
        {
            if (Duration == 0)
            {
                player.Effects.Remove(this);
            }

            _effectLogger.EffectLog(player, "SkipMove");

            Duration--;
        }
    }
}
