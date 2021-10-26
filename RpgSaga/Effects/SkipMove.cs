﻿namespace RpgSaga.Effects
{
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Players;

    public class SkipMove : IEffect, IMoveSkipping
    {
        private ILogger _effectLogger;

        public SkipMove(ILogger effectLogger, int duration)
        {
            _effectLogger = effectLogger;
            Duration = duration;
        }

        public int Duration { get; private set; }

        public void EffectAction(Player player)
        {
            _effectLogger.EffectLog(player, "SkipMove");

            Duration--;
        }
    }
}
