namespace RpgSaga.User
{
    using System;
    using RpgSaga.Consts;

    public class UserActions
    {
        public LogType InputForChoosingLogger()
        {
            var input = Console.ReadLine().ToString();
            LogType log = (LogType)int.Parse(input);

            return log;
        }

        public int InputForChoosingNumberOfPlayers()
        {
            var input = Console.ReadLine().ToString();
            return int.Parse(input);
        }

        public string InputForTheFilePath()
        {
            string input = Console.ReadLine().ToString();
            return input;
        }
    }
}
