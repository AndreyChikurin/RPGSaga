namespace RpgSagaLib.Interfaces
{
    using RpgSagaLib.Players;

    public interface ISkill
    {
        public bool SkillCanBeUsed { get; }

        public void SkillAction(Player soursePlayer, Player targetPlayer);
    }
}
