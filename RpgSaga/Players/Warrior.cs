namespace RpgSaga.Players
{
    public class Warrior : Player
    {
        public bool MortalStrike { get; set; }

        public void Flag()
        {
            MortalStrike = !MortalStrike;
        }
    }
}
