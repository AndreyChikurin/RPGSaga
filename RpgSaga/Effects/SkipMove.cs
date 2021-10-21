namespace RpgSaga.Effects
{
    using RpgSaga.Interfaces;
    using RpgSaga.Players;

    public class SkipMove : IEffect
    {
        public int Duration { get => Duration; set => Duration = 1; }

        public void EffectAction(Player player)
        {
        }
    }
}
