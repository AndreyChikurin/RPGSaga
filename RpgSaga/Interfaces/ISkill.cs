namespace RpgSaga.Interfaces
{
    using RpgSaga.Players;

    public interface ISkill
    {
        public void SkillAction(Player soursePlayer, Player targetPlayer);
    }
}
