namespace CourseApp
{
    using RpgSaga.NewFolder;
    using RpgSaga.Players;

    public class Program
    {
        public static void Main(string[] args)
        {
            Player p1 = CreatePlayers.NewPlayer1();
            Player p2 = CreatePlayers.NewPlayer2();
            Battle.BattleLog(p1, p2);
        }
    }
}
