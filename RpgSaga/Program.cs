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
                int.TryParse(Console.ReadLine(), out var loggerType);

                Console.Write("Please select an even number of players: ");
                int.TryParse(Console.ReadLine(), out var playersNumber);

                game.Start(loggerType, playersNumber);

                if (!game.GameHaveCompleted)
                {
                    foreach (string errorMessage in game.ErrorMessage)
                    {
                        Console.WriteLine(errorMessage);
                    }
                }
            }
        }
    }
}
