namespace RpgSaga.Skills
{
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;
    using RpgSaga.Players;

    public class Freezing : ISkill
    {
        public void SkillAction(Player soursePlayer, Player targetPlayer)
        {
            targetPlayer.Effects.Add(new SkipMove());
        }
    }
}
