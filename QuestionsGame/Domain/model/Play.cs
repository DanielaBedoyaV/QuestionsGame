using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.model
{
    public class Play
    {
        public Play(List<Round> rounds, Player player, int actualRound, bool isActive, string id = null )
        {
            if (id == null)
            {
                this.Id = Guid.NewGuid().ToString();
            }
            else
            {
                this.Id = id;
            }
            this.ActualRound = actualRound;
            this.Player = player;
            this.Rounds = rounds;
            this.IsActive = isActive;
        }
        public Player Player { get; private set; }
        public List<Round> Rounds { get; private set; }
        public int ActualRound { get; private set; }
        public bool IsActive { get; private set; }
        public string Id { get; set; }


    }
}
