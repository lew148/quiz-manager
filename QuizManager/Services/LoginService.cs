using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using quizManager.Data.Repos;
using quizManager.QuizManager.Requests;
using quizManager.QuizManager.SessionModels;
using quizManager.Shared.Constants;
using static BCrypt.Net.BCrypt;

namespace quizManager.QuizManager.Services
{
    public interface ILoginService
    {
        void Login(LoginRequest request);
    }

    public class LoginService : ILoginService
    {
        private readonly IUserRepo userRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginService(IUserRepo userRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.userRepo = userRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void Login(LoginRequest request)
        {
            var user = userRepo.GetUserByUsername(request.Username);

            GeneralHelpers.ThrowIfNull(user);
            if (!Verify(request.Password, user.Password)) throw new Exception("Username/Password is wrong");

            var userSessionModel = new UserSessionModel
            {
                Id = user.Id,
                LoggedIn = true,
                Permission = user.Permission
            };

            httpContextAccessor.HttpContext.Session.SetString(SessionKeys.UserSessionKey,
                JsonConvert.SerializeObject(userSessionModel));
        }
    }
}