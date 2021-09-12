using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.model
{
    public class Player
    {
        public Player(int total, string name)
        {
            this.Name = name;
            this.Total = total;
        }
        public int Total { get; private set; }
        public string Name { get; private set; }
    }
}
