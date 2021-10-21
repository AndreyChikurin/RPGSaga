namespace RpgSaga.Effects
{
    using RpgSaga.Interfaces;
    using RpgSaga.Players;

    public class Burning : IEffect
    {
        public int Duration { get => Duration; set => Duration = 1; }

        public void EffectAction(Player player)
        {
            player.Hp -= 2;
        }
    }
}
