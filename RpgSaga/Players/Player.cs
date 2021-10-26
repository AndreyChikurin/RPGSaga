namespace RpgSaga.Players
{
    using System.Collections.Generic;
    using System.Linq;
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;

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

        public bool ShouldSkipMove
        {
            get { return Effects.OfType<IMoveSkipping>().Any(); }
        }

        public void Reset()
        {
            Hp = MaxHp;
            Effects.Clear();
            IsCurrentRoundFinished = false;
        }

        public void PerformEffects()
        {
            foreach (IEffect effect in Effects)
            {
                effect.EffectAction(this);
            }

            RemoveEffects();
        }

        public void RemoveEffects()
        {
            Effects.RemoveAll(effect => effect.Duration == 0);
        }

        public bool MoveSkipping()
        {
            return Effects.OfType<IMoveSkipping>().Any();
        }

        public void Punch(Player defender, ILogger logger)
        {
            defender.Hp -= Strength;
            logger.FightLog(this, defender);
        }
    }
}
