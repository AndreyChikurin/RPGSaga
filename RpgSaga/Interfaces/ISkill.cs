namespace RpgSaga.Interfaces
{
    using RpgSaga.Players;

    public interface ISkill
    {
        public bool SkillCanBeUsed { get; set; }

        public void SkillAction(Player soursePlayer, Player targetPlayer);
    }
}
