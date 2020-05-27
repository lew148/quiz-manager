using Microsoft.AspNetCore.Mvc;
using quizManager.QuizManager.Responses;
using quizManager.QuizManager.Services;

namespace quizManager.QuizManager.Controllers
{
    [ApiController]
    [Route("/api/session")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService sessionService;

        public SessionController(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        [HttpGet]
        public ActionResult<UserSessionResponse> GetSession()
        {
            var response = sessionService.GetUserSession();
            return Ok(response);
        }
    }
}