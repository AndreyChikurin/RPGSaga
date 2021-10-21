namespace RpgSaga.Players
{
    using System.Collections.Generic;
    using RpgSaga.Interfaces;

    public class Hunter : Player
    {
        public Hunter(int strength, int maxHp, string name, List<ISkill> skills)
            : base(strength, maxHp, name, skills)
        {
        }
    }
}