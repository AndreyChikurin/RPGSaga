namespace CourseApp
{
    using RpgSaga;
    using RpgSaga.Consts;

    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game((LogType)0, 6);
            game.Start();
        }
    }
}
