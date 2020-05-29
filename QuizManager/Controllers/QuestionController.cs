using Microsoft.AspNetCore.Mvc;
using quizManager.QuizManager.Requests;
using quizManager.QuizManager.Services;

namespace quizManager.QuizManager.Controllers
{
    [ApiController]
    [Route("/api/question")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService questionService;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddQuestion([FromForm] AddQuestionRequest request)
        {
            questionService.AddQuestion(request);
            return Ok();
        }
    }
}