namespace RpgSaga.Interfaces
{
    using RpgSaga.Players;

    public interface IEffect
    {
        public int Duration { get; }

        public void EffectAction(Player player);
    }
}
