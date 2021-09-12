using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.model
{
    public class Game
    {
        public Game(List<Round> rounds)
        {
            this.Rounds = rounds;
        }
        public List<Round> Rounds { get; private set; }
    }
}
