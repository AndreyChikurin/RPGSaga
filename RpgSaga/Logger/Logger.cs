namespace RpgSaga.Logger
{
    using System;
    using RpgSaga.Players;

    public class Logger : IEffectLogger, IFightLogger, ISkillLogger, IWinnerLogger
    {
        public static void EffectLog(Player player, string effectName)
        {
            Console.WriteLine(player.GetType().Name + " " + player.Name + $" is under the effect {effectName}");
        }

        public static void FightLog(Player attacker, Player defender)
        {
            Console.WriteLine(attacker.GetType().Name + " " + attacker.Name + $" deals {attacker.Strength} damage to the " + defender.GetType().Name + " " + defender.Name + $"({defender.Hp}Hp)");
        }

        public static void SkillLog(Player soursePlayer, Player targetPlayer, string skillName)
        {
            Console.WriteLine(soursePlayer.GetType().Name + " " + soursePlayer.Name + $" uses {skillName} on the " + targetPlayer.GetType().Name + " " + targetPlayer.Name);
        }

        public static void WinnerLog(Player winner)
        {
            Console.WriteLine("The " + winner.GetType().Name + " " + winner.Name + " won");
        }
    }
}
