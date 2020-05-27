using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quizManager.Data.Responses;

namespace quizManager.Controllers
{
    [ApiController]
    [Route("/api/session")]
    public class SessionController : ControllerBase
    {
        [HttpGet]
        public ActionResult<SessionResponse> GetSession()
        {
            var loggedIn = false;

            try
            {
                loggedIn = Boolean.Parse(HttpContext.Session.GetString("loggedIn"));
            } 
            catch (ArgumentNullException) {}

            var response = new SessionResponse
            {
                LoggedIn = loggedIn,
            };
            
            return Ok(response);
        }
    }
}