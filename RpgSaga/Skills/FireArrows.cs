namespace RpgSaga.Skills
{
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;
    using RpgSaga.Logger;
    using RpgSaga.Players;

    public class FireArrows : ISkill
    {
        public void SkillAction(Player soursePlayer, Player targetPlayer)
        {
            targetPlayer.Effects.Add(new Burning());

            Logger.SkillLog(soursePlayer, targetPlayer, "FireArrows");
        }
    }
}
