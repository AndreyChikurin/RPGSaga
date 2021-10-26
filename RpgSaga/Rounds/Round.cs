namespace RpgSaga.Rounds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RpgSaga.Loggers;
    using RpgSaga.Players;

    public class Round
    {
        private List<Player> _players;

        private ILogger _logger;

        public Round(List<Player> players, ILogger logger)
        {
            _players = players;
            _logger = logger;
        }

        public void Start()
        {
            RefreshPlayers();
            CrateFights();
        }

        private Player GetAvailiablePlayer()
        {
            Random random = new Random();
            List<Player> availablePlayer = _players.Where(player => player.IsCurrentRoundFinished == false).ToList();
            int playerNumber = random.Next(0, availablePlayer.Count);
            availablePlayer[playerNumber].IsCurrentRoundFinished = true;
            return availablePlayer[playerNumber];
        }

        private void CrateFights()
        {
            for (int i = 0; i < _players.Count / 2; i++)
            {
                Player firstPlayer = GetAvailiablePlayer();
                Player secondPlayer = GetAvailiablePlayer();
                Fight fight = new Fight(firstPlayer, secondPlayer, _logger);
                _players.Remove(fight.Start());
            }
        }

        private void RefreshPlayers()
        {
            _players.ForEach(player => player.IsCurrentRoundFinished = false);
        }
    }
}