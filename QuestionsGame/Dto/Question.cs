using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto
{
    public class Question
    {
        public string StatementQuestion { get; set; }

        public List<Answer> Answers { get; set; }

        public string Id { get; set; }

    }
}
