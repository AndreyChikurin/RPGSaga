namespace RpgSaga.Players
{
    using System.Collections.Generic;
    using RpgSaga.Interfaces;

    public class Mage : Player
    {
        public Mage(int strength, int maxHp, string name, List<ISkill> skills)
            : base(strength, maxHp, name, skills)
        {
        }
    }
}