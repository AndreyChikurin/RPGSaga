namespace CourseApp
{
    using System;
    using RpgSaga.Players;

    public class Program
    {
        public static void Main(string[] args)
        {
            Player p1 = new Mage { Name = "Oruma", Hp = 20, Strength = 3 };
            Player p2 = new Warrior { Name = "Hrago", Hp = 30, Strength = 2 };
            Battle(p1, p2);
        }

        public static void Battle(Player p1, Player p2)
        {
            while (p1.Hp > 0 && p2.Hp > 0)
            {
                p2.Hp -= p1.Strength;
                Console.WriteLine(p1.GetType().Name + " " + p1.Name + $" deals {p1.Strength} damage to the " + p2.GetType().Name + " " + p2.Name + $"({p2.Hp}Hp)");

                if (p1.Hp > 0 && p2.Hp > 0)
                {
                    p1.Hp -= p2.Strength;
                    Console.WriteLine(p2.GetType().Name + " " + p2.Name + $" deals {p2.Strength} damage to the " + p1.GetType().Name + " " + p1.Name + $"({p1.Hp}Hp)");
                }
            }

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
