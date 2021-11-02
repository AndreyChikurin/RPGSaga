namespace RpgSagaLib.Loggers
{
    using System;
    using System.IO;
    using RpgSagaLib.Players;

    public class LoggerForFile : ILogger
    {
        private static string _filePath;

        private string path;

        public LoggerForFile(string filePath)
        {
            _filePath = filePath;
            path = Path.Combine($@"{_filePath}", $"Log#{DateTime.Now.ToString("dd.MM.yyyy")}.txt");
        }

        public void EffectLog(Player player, string effectName)
        {
            File.WriteAllText(path, player.GetType().Name + " " + player.Name + $" is under the effect {effectName} ({player.Hp}Hp)");
        }

        public void FightLog(Player attacker, Player defender)
        {
            File.WriteAllText(path, attacker.GetType().Name + " " + attacker.Name + $" deals {attacker.Strength} damage to the " + defender.GetType().Name + " " + defender.Name + $"({defender.Hp}Hp)");
        }

        public void SkillLog(Player soursePlayer, Player targetPlayer, string skillName)
        {
            File.WriteAllText(path, soursePlayer.GetType().Name + " " + soursePlayer.Name + $" uses {skillName} on the " + targetPlayer.GetType().Name + " " + targetPlayer.Name + $"({targetPlayer.Hp}Hp)");
        }

        public void WinnerLog(Player winner)
        {
            File.WriteAllText(path, "The " + winner.GetType().Name + " " + winner.Name + " won");
        }
    }
}