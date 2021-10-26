namespace RpgSaga.Skills
{
    using System;
    using RpgSaga.Players;

    public static class SkillsLogic
    {
        public static void PerfomSkill(Player attacker, Player defender)
        {
            if (attacker.Skills.Count > 0)
            {
                Random random = new Random();
                attacker.Skills[random.Next(0, attacker.Skills.Count)].SkillAction(attacker, defender);
            }
        }
    }
}
