using Domain.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Services
{
   public class GameServices
    {
        

        public GameServices()
        {

        }

        public Dto.Play Play(Dto.Play playDto)
        {
            var random = new Random();
            if (playDto.Id ==null)
            {
                List<Category> categories;
                Prize prize;
                Question randomQuestion;
                Play play = this.StartGame(playDto, random, out categories, out prize, out randomQuestion);

                Dto.Round round = this.RoundMap(categories, prize, randomQuestion);
                return new Dto.Play() { Id = play.Id, Rounds = new List<Dto.Round>() { round }, Player = playDto.Player, IsActive = play.IsActive  };

            }
           
            Play oldGame = this.GetGame(playDto.Id);
            this.ValidateCorrectAnswer(oldGame, playDto);


            return new Dto.Play();

        }

        private Dto.Play ValidateCorrectAnswer(Play oldGame, Dto.Play playDto)
        {
            var random = new Random();
            Round actualRound = oldGame.Rounds[oldGame.ActualRound];
            Question question = actualRound.Category.Questions.FirstOrDefault(x => x.Id == playDto.Rounds.FirstOrDefault().Category.Questions.FirstOrDefault().Id);
            if (!question.Answers.FirstOrDefault(x => x.StatementAnswer == playDto.Rounds.FirstOrDefault().Category.Questions.FirstOrDefault().Answers.FirstOrDefault().StamentAnswer).IsCorrect)
            {
                Play newPlay = new Play(oldGame.Rounds, oldGame.Player, 1, false, oldGame.Id);
                this.SaveGame(newPlay);
                throw new InvalidOperationException("Incorrect answer, game over");
            }
            if (oldGame.ActualRound + 1 > 4)
            {
                throw new InvalidOperationException("You win");
            }
            Play continuePlay = new Play(oldGame.Rounds, oldGame.Player, oldGame.ActualRound + 1, false, oldGame.Id);
            Prize prize = new Prize(10, 10);
            Question randomQuestion;
            int index = random.Next(4);
            randomQuestion = oldGame.Rounds[continuePlay.ActualRound].Category.Questions[index];
            this.SaveGame(continuePlay);
            Dto.Round round = this.RoundMap( prize, randomQuestion);

            return new Dto.Play() { Id = continuePlay.Id, Rounds = new List<Dto.Round>() { round }, Player = playDto.Player, IsActive = continuePlay.IsActive };

        }

        private Dto.Round RoundMap(Prize prize, Question randomQuestion)
        {
            List<Dto.Answer> answers = new List<Dto.Answer>();
            foreach (var answer in randomQuestion.Answers)
            {
                answers.Add(new Dto.Answer() { StamentAnswer = answer.StatementAnswer });
            }
            Dto.Question question = new Dto.Question()
            {
                StatementQuestion = randomQuestion.StatementQuestion,
                Answers = answers
            };

            Dto.Category categoryInGame = new Dto.Category()
            {
                Questions = new List<Dto.Question>() { question }
            };

            return new Dto.Round() { Category = categoryInGame, Prize = new Dto.Prize() { Cash = prize.Cash, Points = prize.Points } };
        }

        private Play StartGame(Dto.Play playDto, Random random, out List<Category> categories, out Prize prize, out Question randomQuestion)
        {
            Player player = new Player(0, playDto.Player.Name);
            List<Round> rounds = new List<Round>();
            CategoryServices categoryServices = new CategoryServices();
            categories = categoryServices.GetCategories();
            prize = new Prize(10, 10);
            for (int i = 1; i < 6; i++)
            {
                Category category = categories.FirstOrDefault(category => category.Level == i);
                rounds.Add(new Round(category, prize));
            }
            int index = random.Next(4);
            Play newPlay = new Play(rounds, player, 1, true);

            randomQuestion = categories.FirstOrDefault(category => category.Level == 1).Questions[index];
            this.SaveGame(newPlay);
            return newPlay;
        }

        private Dto.Round RoundMap(List<Category> categories, Prize prize, Question randomQuestion)
        {
            List<Dto.Answer> answers = new List<Dto.Answer>();
            foreach (var answer in randomQuestion.Answers)
            {
                answers.Add(new Dto.Answer() { StamentAnswer = answer.StatementAnswer });
            }
            Dto.Question question = new Dto.Question()
            {
                StatementQuestion = randomQuestion.StatementQuestion,
                Answers = answers
            };

            Dto.Category categoryInGame = new Dto.Category()
            {
                Questions = new List<Dto.Question>() { question },
                CategoryName = categories.FirstOrDefault(category => category.Level == 1).CategoryName,
                Level = 1,
                Id = categories.FirstOrDefault(category => category.Level == 1).Id
            };

            return new Dto.Round() { Category = categoryInGame, Prize = new Dto.Prize() { Cash = prize.Cash, Points = prize.Points } };
        }

       
        private void SaveGame(Play play)
        {

            var path = @"./files/" + play.Id + ".json";

            string json = System.Text.Json.JsonSerializer.Serialize(play);
            File.WriteAllText(path, json);
        }

        private Play GetGame(string gameId)
        {

            var path = @"./files/" + gameId;

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                Play item = JsonConvert.DeserializeObject<Play>(json);
                return item;
            }


        }
    }
}
