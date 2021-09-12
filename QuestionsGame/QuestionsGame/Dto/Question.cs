using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsGame.Dto
{
    public class Question
    {
        public string StatementQuestion { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
