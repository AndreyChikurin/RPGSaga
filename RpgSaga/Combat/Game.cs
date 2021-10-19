namespace RpgSaga.Combat
{
    using System;
    using RpgSaga.Players;

    public class Game
    {
        public void RunGame()
        {
            Player p1 = PlayersCreator.NewPlayer1();
            Player p2 = PlayersCreator.NewPlayer2();

            while (p1.Hp > 0 && p2.Hp > 0)
            {
                PlayerMove(p1, p2);

                if (p2.Hp > 0)
                {
                    PlayerMove(p2, p1);
                }
            }

            Winner(p1, p2);
        }

        private void PlayerMove(Player attacker, Player defender)
        {
            defender.Hp -= attacker.Strength;
            Console.WriteLine(attacker.GetType().Name + " " + attacker.Name + $" deals {attacker.Strength} damage to the " + defender.GetType().Name + " " + defender.Name + $"({defender.Hp}Hp)");
        }

        private void Winner(Player p1, Player p2)
        {
            Console.WriteLine();

            var winner = p1;

            if (p2.Hp > 0)
            {
                winner = p2;
            }

            Console.WriteLine("The " + winner.GetType().Name + " " + winner.Name + " won");
        }
    }
}
