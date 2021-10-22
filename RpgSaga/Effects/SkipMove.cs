namespace RpgSaga.Effects
{
    using RpgSaga.Interfaces;
    using RpgSaga.Logger;
    using RpgSaga.Players;

    public class SkipMove : IEffect
    {
        public int Duration { get => Duration; set => Duration = 1; }

        public void EffectAction(Player player)
        {
            if (Duration == 0)
            {
                player.Effects.Remove(new SkipMove());
            }

            Logger.EffectLog(player, "SkipMove");

            Duration--;
        }
    }
}
