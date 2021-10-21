namespace RpgSaga.Effects
{
    using RpgSaga.Interfaces;
    using RpgSaga.Players;

    public class Burning : IEffect
    {
        public int Duration { get => Duration; set => Duration = 10; }

        public void EffectAction(Player player)
        {
            if (Duration > 0)
            {
                player.Hp -= 2;
            }
        }
    }
}
