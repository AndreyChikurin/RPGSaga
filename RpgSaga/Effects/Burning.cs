namespace RpgSaga.Effects
{
    using RpgSaga.Interfaces;
    using RpgSaga.Logger;
    using RpgSaga.Players;

    public class Burning : IEffect
    {
        public int Duration { get => Duration; set => Duration = 1; }

        public void EffectAction(Player player)
        {
            player.Hp -= 2;

            Logger.EffectLog(player, "Burning and deal 2 damage");
        }
    }
}
