namespace RpgSagaLib.Players
{
    using System.Collections.Generic;
    using RpgSagaLib.Interfaces;

    public class Mage : Player
    {
        public Mage(int strength, int maxHp, string name, List<ISkill> skills)
            : base(strength, maxHp, name, skills)
        {
        }
    }
}