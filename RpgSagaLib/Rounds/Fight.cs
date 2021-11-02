namespace RpgSagaLib.Rounds
{
    using System;
    using RpgSagaLib.Loggers;
    using RpgSagaLib.Players;

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

        public Player Start()
        {
            FightAction();
            return ResetAfterFight();
        }

        private Player ResetAfterFight()
        {
            Player looser;

            if (_attacker.Hp > 0)
            {
                _attacker.Reset();
                looser = _defender;
            }
            else
            {
                _defender.Reset();
                looser = _attacker;
            }

            return looser;
        }

        private void Attack(Player attacker, Player defender)
        {
            Random random = new Random();

            if (attacker.ShouldSkipMove)
            {
                attacker.PerformEffects();
                return;
            }

            if (random.Next(1, 10) >= 7)
            {
                var attackerSkill = attacker.Skills[random.Next(0, attacker.Skills.Count)];
                if (attackerSkill.SkillCanBeUsed)
                {
                    attackerSkill.SkillAction(attacker, defender);
                    attacker.PerformEffects();
                    return;
                }
            }

            attacker.Punch(defender, _fightLogger);

            if (defender.Hp > 0)
            {
                attacker.PerformEffects();
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
