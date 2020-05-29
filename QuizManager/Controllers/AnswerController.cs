using Microsoft.AspNetCore.Mvc;
using quizManager.QuizManager.Requests;
using quizManager.QuizManager.Services;

namespace quizManager.QuizManager.Controllers
{
    [ApiController]
    [Route("/api/answer")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService answerService;

        public AnswerController(IAnswerService answerService)
        {
            this.answerService = answerService;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddAnswer([FromForm] AddAnswerRequest request)
        {
            answerService.AddAnswer(request);
            return Ok();
        }
    }
}