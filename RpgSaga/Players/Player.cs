namespace RpgSaga.Players
{
    using System.Collections.Generic;
    using RpgSaga.Interfaces;

    public abstract class Player
    {
        public Player(int strength, int maxHp, string name, List<ISkill> skills)
        {
            Strength = strength;
            MaxHp = maxHp;
            Hp = maxHp;
            Name = name;
            Skills = skills;
            Effects = new List<IEffect>();
            IsCurrentRoundFinished = false;
        }

        public int Strength { get; set; }

        public int Hp { get; set; }

        public int MaxHp { get; private set; }

        public string Name { get; set; }

        public bool IsCurrentRoundFinished { get; set; }

        public List<IEffect> Effects { get; set; }

        public List<ISkill> Skills { get; set; }

        public void Reset()
        {
            Hp = MaxHp;
            Effects.Clear();
            IsCurrentRoundFinished = false;
        }
    }
}
