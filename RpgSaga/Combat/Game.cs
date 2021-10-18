namespace RpgSaga.Combat
{
    using System;
    using RpgSaga.Players;

    public class Game
    {
        public static void BattleLog()
        {
            Player p1 = PlayersCreator.NewPlayer1();
            Player p2 = PlayersCreator.NewPlayer2();

            while (p1.Hp > 0 && p2.Hp > 0)
            {
                PlayerMove(p1, p2, true);

                if (p2.Hp > 0)
                {
                    PlayerMove(p1, p2, false);
                }
            }

            Winner(p1, p2);
        }

        public static void PlayerMove(Player p1, Player p2, bool firstPlayerMove)
        {
            if (firstPlayerMove)
            {
                p2.Hp -= p1.Strength;
                Console.WriteLine(p1.GetType().Name + " " + p1.Name + $" deals {p1.Strength} damage to the " + p2.GetType().Name + " " + p2.Name + $"({p2.Hp}Hp)");
            }

            if (!firstPlayerMove)
            {
                p1.Hp -= p2.Strength;
                Console.WriteLine(p2.GetType().Name + " " + p2.Name + $" deals {p2.Strength} damage to the " + p1.GetType().Name + " " + p1.Name + $"({p1.Hp}Hp)");
            }
        }

        public static void Winner(Player p1, Player p2)
        {
            Console.WriteLine();

            if (p1.Hp > 0)
            {
                Console.WriteLine("The " + p1.GetType().Name + " " + p1.Name + " won");
            }
            else
            {
                Console.WriteLine("The " + p2.GetType().Name + " " + p2.Name + " won");
            }
        }
    }
}
