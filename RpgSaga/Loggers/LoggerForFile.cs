namespace RpgSaga.Loggers
{
    using System.IO;
    using RpgSaga.Players;

    public class LoggerForFile : Logger
    {
        private readonly string path = @"c:\Users\andre\Desktop\MyTest.txt";

        public override void EffectLog(Player player, string effectName)
        {
            File.WriteAllText(path, player.GetType().Name + " " + player.Name + $" is under the effect {effectName}");
        }

        public override void FightLog(Player attacker, Player defender)
        {
            File.WriteAllText(path, attacker.GetType().Name + " " + attacker.Name + $" deals {attacker.Strength} damage to the " + defender.GetType().Name + " " + defender.Name + $"({defender.Hp}Hp)");
        }

        public override void SkillLog(Player soursePlayer, Player targetPlayer, string skillName)
        {
            File.WriteAllText(path, soursePlayer.GetType().Name + " " + soursePlayer.Name + $" uses {skillName} on the " + targetPlayer.GetType().Name + " " + targetPlayer.Name);
        }

        public override void WinnerLog(Player winner)
        {
            File.WriteAllText(path, "The " + winner.GetType().Name + " " + winner.Name + " won");
        }
    }
}