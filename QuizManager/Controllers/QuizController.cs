using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using quizManager.Data.Models;
using quizManager.QuizManager.Requests;
using quizManager.QuizManager.Responses;
using quizManager.QuizManager.Services;

namespace quizManager.QuizManager.Controllers
{
    [ApiController]
    [Route("/api/quiz")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService quizService;

        public QuizController(IQuizService quizService)
        {
            this.quizService = quizService;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<QuizListResponse>> GetAllQuizzes()
        {
            var response = quizService.GetAllQuizzes();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Quiz> GetQuiz(int id)
        {
            var response = quizService.GetQuiz(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddQuiz([FromForm] AddQuizRequest request)
        {
            quizService.AddQuiz(request);
            return Ok();
        }
        
        [HttpPost]
        [Route("delete/{quizId}")]
        public ActionResult DeleteQuiz(int quizId)
        {
            quizService.DeleteQuiz(quizId);
            return Ok();
        }
    }
}