namespace RpgSaga.Interfaces
{
    using RpgSaga.Players;

    public interface IEffect
    {
        public int Duration { get; set; }

        public void EffectAction(Player player);
    }
}
