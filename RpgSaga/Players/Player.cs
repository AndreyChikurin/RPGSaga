namespace RpgSaga.Players
{
    using System.Collections.Generic;
    using RpgSaga.Interfaces;

    public abstract class Player
    {
        public Player(int strength, int hp, string name, List<ISkill> skills)
        {
            this.Strength = strength;
            this.Hp = hp;
            this.Name = name;
            this.Skills = skills;
            this.Effects = new List<IEffect>();
            this.IsCurrentRoundFinished = true;
        }

        public int Strength { get; set; }

        public int Hp { get; set; }

        public int MaxHp { get; set; }

        public string Name { get; set; }

        public bool IsCurrentRoundFinished { get; set; }

        public List<IEffect> Effects { get; set; }

        public List<ISkill> Skills { get; set; }

        public void Reset()
        {
            this.Hp = MaxHp;
            this.Effects.Clear();
        }
    }
}
