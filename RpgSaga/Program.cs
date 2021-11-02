namespace CourseApp
{
    using System;
    using RpgSaga;

    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();

            while (!game.GameHaveCompleted)
            {
                string playersNumber = null;

                Console.Write("Enter 1 to write logs to a file or 0 to write logs to the console: ");
                string loggerType = Console.ReadLine();

                Console.Write("Enter 0 to load players from a Json file or enter 1 for random generation of players: ");
                string playersGenerationType = Console.ReadLine();

                if (playersGenerationType == "1")
                {
                    Console.Write("Please select an even number of players: ");
                    playersNumber = Console.ReadLine();
                }

                game.Start(loggerType, playersNumber, playersGenerationType);

                foreach (string errorMessage in game.ErrorMessages)
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }
    }
}
