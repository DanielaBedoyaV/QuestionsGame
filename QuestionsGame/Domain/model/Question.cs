using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.model
{
    public class Question
    {
        public Question(string statementQuestion, List<Answer> answers, string id = null)
        {
            if (id == null)
            {
                this.Id = Guid.NewGuid().ToString();
            }
            else
            {
                this.Id = id;
            } 
            this.Answers = answers;
            this.StatementQuestion = statementQuestion;
        }
        public string StatementQuestion { get; private set; }

        public List<Answer> Answers { get; private set; }

        public string Id { get; private set; }
    }
}
