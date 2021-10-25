namespace CourseApp
{
    using RpgSaga;
    using RpgSaga.Consts;

    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game((LogTypes.LogType)1, 4);
        }
    }
}
