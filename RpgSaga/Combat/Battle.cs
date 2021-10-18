namespace RpgSaga.NewFolder
{
    using System;
    using RpgSaga.Players;

    public class Battle
    {
        public static void BattleLog(Player p1, Player p2)
        {
            while (p1.Hp > 0 && p2.Hp > 0)
            {
                FirstPlayerMove(p1, p2);

                if (p2.Hp > 0)
                {
                    SecondPlayerMove(p1, p2);
                }
            }

            Winner(p1, p2);
        }

        public static void FirstPlayerMove(Player p1, Player p2)
        {
            p2.Hp -= p1.Strength;
            Console.WriteLine(p1.GetType().Name + " " + p1.Name + $" deals {p1.Strength} damage to the " + p2.GetType().Name + " " + p2.Name + $"({p2.Hp}Hp)");
        }

        public static void SecondPlayerMove(Player p1, Player p2)
        {
            p1.Hp -= p2.Strength;
            Console.WriteLine(p2.GetType().Name + " " + p2.Name + $" deals {p2.Strength} damage to the " + p1.GetType().Name + " " + p1.Name + $"({p1.Hp}Hp)");
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
