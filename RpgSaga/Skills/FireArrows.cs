namespace RpgSaga.Skills
{
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;
    using RpgSaga.Players;

    public class FireArrows : ISkill
    {
        public void SkillAction(Player soursePlayer, Player targetPlayer)
        {
            targetPlayer.Effects.Add(new Burning());
        }
    }
}
