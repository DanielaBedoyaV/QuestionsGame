using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuestionsGame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public Question QuestionGet()
        {
            return new Question
            
            { StatementQuestion = "quien soy? ",
                                  Answers = new List<Answer> {
                                      new Answer { StamentAnswer = "gelipe",
                                          IsCorrect = true 
                                      } 
                                  } 
            };
        }
    }
}
