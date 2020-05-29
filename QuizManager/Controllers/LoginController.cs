using Microsoft.AspNetCore.Mvc;
using quizManager.QuizManager.Requests;
using quizManager.QuizManager.Services;

namespace quizManager.QuizManager.Controllers
{
    [ApiController]
    [Route("/api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        public ActionResult Login([FromForm] LoginRequest request)
        {
            loginService.Login(request);
            return Ok();
        }
    }
}