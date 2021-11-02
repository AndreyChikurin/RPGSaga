namespace RpgSagaLib.Loggers
{
    using System;
    using RpgSagaLib.Players;

    public class LoggerForConsole : ILogger
    {
        public void EffectLog(Player player, string effectName)
        {
            Console.WriteLine(player.GetType().Name + " " + player.Name + $" is under the effect {effectName} ({player.Hp}Hp)");
        }

        public void FightLog(Player attacker, Player defender)
        {
            Console.WriteLine(attacker.GetType().Name + " " + attacker.Name + $" deals {attacker.Strength} damage to the " + defender.GetType().Name + " " + defender.Name + $"({defender.Hp}Hp)");
        }

        public void SkillLog(Player soursePlayer, Player targetPlayer, string skillName)
        {
            Console.WriteLine(soursePlayer.GetType().Name + " " + soursePlayer.Name + $" uses {skillName} on the " + targetPlayer.GetType().Name + " " + targetPlayer.Name + $"({targetPlayer.Hp}Hp)");
        }

        public void WinnerLog(Player winner)
        {
            Console.WriteLine("The " + winner.GetType().Name + " " + winner.Name + " won");
            Console.WriteLine();
        }
    }
}
