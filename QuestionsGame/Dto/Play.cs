using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto
{
    public class Play
    {
        public Play()
        {
                
        }
        public Player Player { get; set; }
        public List<Round> Rounds { get; set; }
        public int ActualRound { get; set; }
        public bool IsActive { get; set; }
        public string Id { get; set; }
    }
}
