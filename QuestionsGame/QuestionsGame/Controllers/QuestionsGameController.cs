using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dto;
using Services;
using System.Collections.Generic;

namespace QuestionsGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsGameController : ControllerBase
    {

        private readonly ILogger<QuestionsGameController> _logger;

        public QuestionsGameController(ILogger<QuestionsGameController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public Question QuestionPost(Question question)
        {
            QuestionServices questionServices = new QuestionServices();
            questionServices.MapQuestion(question);
            return question;
        }

        [HttpPost("CreateNewCategory")]
        public Category CategoryQuestionsPost(Category category)
        {
            CategoryServices categoryServices = new CategoryServices();
            categoryServices.SetNewCategory(category);
            return category;
        }

        [HttpPost("Play")]
        public Play PlayGamePost( Play play)
        {
            GameServices gameServices = new GameServices();
            Play newPlay = gameServices.Play(play);
            return newPlay;
        }
    }
}
