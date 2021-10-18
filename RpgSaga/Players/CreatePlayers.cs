namespace RpgSaga.Players
{
    public class CreatePlayers
    {
        public static Player NewPlayer1()
        {
            return new Mage { Name = "Oruma", Hp = 20, Strength = 3 };
        }

        public static Player NewPlayer2()
        {
            return new Warrior { Name = "Hrago", Hp = 30, Strength = 2 };
        }
    }
}
