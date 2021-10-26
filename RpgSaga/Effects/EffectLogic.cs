namespace RpgSaga.Effects
{
    using System.Linq;
    using RpgSaga.Interfaces;
    using RpgSaga.Players;

    public static class EffectLogic
    {
        public static void PerformEffects(Player player)
        {
            foreach (IEffect effect in player.Effects)
            {
                effect.EffectAction(player);
            }

            RemoveEffects(player);
        }

        public static void RemoveEffects(Player player)
        {
            player.Effects.RemoveAll(effect => effect.Duration == 0);
        }

        public static bool MoveSkipping(Player player)
        {
            return player.Effects.OfType<IMoveSkipping>().Any();
        }
    }
}
