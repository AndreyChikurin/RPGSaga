namespace RpgSagaLib.Interfaces
{
    using RpgSagaLib.Players;

    public interface IEffect
    {
        public int Duration { get; }

        public void EffectAction(Player player);
    }
}
