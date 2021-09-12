using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.model
{
    public class GameHistory
    {
        public GameHistory(Player player, Game game)
        {
            this.Game = game;
            this.Player = player;

        }
        public Player Player { get; private set; }
        public Game Game { get; private set; }
    }
}
