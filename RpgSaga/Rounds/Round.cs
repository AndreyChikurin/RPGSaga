namespace RpgSaga.Rounds
{
    using System.Collections.Generic;
    using RpgSaga.Players;

    public class Round
    {
        public Round(List<Player> players)
        {
            Players = players;
        }

        public List<Player> Players { get; set; }

        public void Start()
        {
        }
    }
}