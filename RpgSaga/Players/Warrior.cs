namespace RpgSaga.Players
{
    using System.Collections.Generic;
    using RpgSaga.Interfaces;

    public class Warrior : Player
    {
        public Warrior(int strength, int hp, string name, List<ISkill> skills)
            : base(strength, hp, name, skills)
        {
        }
    }
}
