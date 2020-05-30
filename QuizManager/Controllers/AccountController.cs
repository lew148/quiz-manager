using Microsoft.AspNetCore.Mvc;
using quizManager.QuizManager.Requests;
using quizManager.QuizManager.Services;

namespace quizManager.QuizManager.Controllers
{
    [ApiController]
    [Route("/api/account")]
    public class LoginController : ControllerBase
    {
        private readonly IAccountService accountService;

        public LoginController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromForm] LoginRequest request)
        {
            accountService.Login(request);
            return Ok();
        }
        
        [HttpPost]
        [Route("logout")]
        public ActionResult Logout()
        {
            accountService.Logout();
            return Ok();
        }
    }
}