using Domain.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Services
{
    public class QuestionServices
    {
        public QuestionServices()
        {
        }

        public Question MapQuestion(Dto.Question questionDto)
        {
            List<Answer> answers = this.MapAnswers(questionDto.Answers);
            Question question = new Question(questionDto.StatementQuestion, answers);
            this.ValidateQuestion(question);
            return question;
        }

        private void ValidateQuestion(Question question)
        {
            if (question.Answers.Count != 4)
            {
                throw new InvalidOperationException("It has to be 4 answers");
            }
            if (question.Answers.Count(item => item.IsCorrect) != 1)
            {
                throw new InvalidOperationException("Only one answer can be correct");
            }
        }

        private List<Answer> MapAnswers(List<Dto.Answer> answersDto)
        {
            List<Answer> answers = new List<Answer>();
            foreach (var answer in answersDto)
            {
                answers.Add(new Answer(answer.StamentAnswer, answer.IsCorrect));
            }
            return answers;
        }

    }
}
