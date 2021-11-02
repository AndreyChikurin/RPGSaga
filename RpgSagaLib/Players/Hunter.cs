namespace RpgSagaLib.Players
{
    using System.Collections.Generic;
    using RpgSagaLib.Interfaces;

    public class Hunter : Player
    {
        public Hunter(int strength, int maxHp, string name, List<ISkill> skills)
            : base(strength, maxHp, name, skills)
        {
        }
    }
}