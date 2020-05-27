
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quizManager.Data.Repos;
using quizManager.Data.Requests;
using quizManager.Data.Services;

namespace quizManager.Controllers
{
    [ApiController]
    [Route("/api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Login([FromForm] LoginRequest request)
        {
            userService.Login(request);
            return Ok();
        }
    }
}