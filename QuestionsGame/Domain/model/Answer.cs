using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.model
{
    public class Answer
    {
        public Answer(string statementAnswer, bool isCorrect)
        {
            this.StatementAnswer = statementAnswer;
            this.IsCorrect = isCorrect;
        }
        public string StatementAnswer { get; private set; }
        public bool IsCorrect { get; private set; }

    }
}
