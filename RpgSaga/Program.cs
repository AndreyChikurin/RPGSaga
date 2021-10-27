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
                Console.WriteLine(loggerType);

                Console.Write("Please select an even number of players: ");
                int.TryParse(Console.ReadLine(), out var playersNumber);
                Console.WriteLine(playersNumber);

                game.Start(loggerType, playersNumber);

                if (!game.GameHaveCompleted)
                {
                    Console.WriteLine(game.ErrorMessage);
                }
            }
        }
    }
}
