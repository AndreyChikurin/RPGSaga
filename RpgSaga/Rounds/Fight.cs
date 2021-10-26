namespace RpgSaga.Rounds
{
    using System;
    using RpgSaga.Effects;
    using RpgSaga.Loggers;
    using RpgSaga.Players;
    using RpgSaga.Skills;

    public class Fight
    {
        private ILogger _fightLogger;

        private Player _attacker;

        private Player _defender;

        public Fight(Player attacker, Player defender, ILogger fightLogger)
        {
            _attacker = attacker;
            _defender = defender;
            _fightLogger = fightLogger;
        }

        public void Start()
        {
            FightAction();
            ResetAfterFight();
        }

        private void ResetAfterFight()
        {
            if (_attacker.Hp > 0)
            {
                _attacker.Reset();
            }
            else
            {
                _defender.Reset();
            }
        }

        private void Attack(Player attacker, Player defender)
        {
            Random random = new Random();

            if (EffectLogic.MoveSkipping(attacker))
            {
                EffectLogic.PerformEffects(attacker);
                Attack(defender, attacker);
            }
            else if (random.Next(1, 10) < 6)
            {
                Hit.Punch(attacker, defender, _fightLogger);
            }
            else
            {
                SkillsLogic.PerfomSkill(attacker, defender);
            }

            if (defender.Hp > 0)
            {
                EffectLogic.PerformEffects(attacker);
            }
        }

        private void FightAction()
        {
            while (_attacker.Hp > 0 && _defender.Hp > 0)
            {
                Attack(_attacker, _defender);

                if (_defender.Hp > 0)
                {
                    Attack(_defender, _attacker);
                }
            }

            _fightLogger.WinnerLog(_attacker.Hp > 0 ? _attacker : _defender);
        }
    }
}
