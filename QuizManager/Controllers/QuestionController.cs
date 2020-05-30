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

        [HttpPost]
        [Route("delete/{questionId}")]
        public ActionResult DeleteQuestion(int questionId)
        {
            questionService.DeleteQuestion(questionId);
            return Ok();
        }
        
        [HttpPost]
        [Route("edit/{questionId}")]
        public ActionResult EditQuestion(int questionId, [FromForm] EditRequest request)
        {
            questionService.EditQuestion(questionId, request);
            return Ok();
        }
    }
}