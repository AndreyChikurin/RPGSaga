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
                Console.Write("Enter 1 to write logs to a file or 0 to write logs to the console: ");
                string loggerType = Console.ReadLine();

                Console.Write("Please select an even number of players: ");
                string playersNumber = Console.ReadLine();

                game.Start(loggerType, playersNumber);

                foreach (string errorMessage in game.ErrorMessages)
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }
    }
}
