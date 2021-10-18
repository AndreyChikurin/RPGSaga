namespace RpgSaga.Players
{
    public class Mage : Player
    {
        public bool Freezing { get; set; }

        public void Flag()
        {
            Freezing = !Freezing;
        }
    }
}
