namespace RpgSaga.Skills
{
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;
    using RpgSaga.Logger;
    using RpgSaga.Players;

    public class Freezing : ISkill
    {
        public void SkillAction(Player soursePlayer, Player targetPlayer)
        {
            targetPlayer.Effects.Add(new SkipMove());

            Logger.SkillLog(soursePlayer, targetPlayer, "Freezing");
        }
    }
}
