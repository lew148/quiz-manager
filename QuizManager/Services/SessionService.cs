using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using quizManager.QuizManager.Responses;
using quizManager.QuizManager.SessionModels;
using quizManager.Shared.Constants;

namespace quizManager.QuizManager.Services
{
    public interface ISessionService
    {
        public UserSessionResponse GetUserSession();
    }
    
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public UserSessionResponse GetUserSession()
        {
            UserSessionResponse response = null;
                
            try
            {
                var sessionModel = JsonConvert
                    .DeserializeObject<UserSessionModel>(
                        httpContextAccessor.HttpContext.Session.GetString(SessionKeys.UserSessionKey));
                
                response = new UserSessionResponse
                {
                    Id = sessionModel.Id,
                    LoggedIn = sessionModel.LoggedIn,
                    Permission = sessionModel.Permission
                };
            }
            catch (ArgumentNullException) { }

            return response;
        }
    }
}