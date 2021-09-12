using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.model
{
    public class Prize
    {
        public Prize(int cash, int points)
        {
            this.Cash = cash;
            this.Points = points;

        }
        public int Cash { get; private set; }
        public int Points { get;private set; }
    }
}
