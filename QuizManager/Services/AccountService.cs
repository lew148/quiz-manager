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
    public interface IAccountService
    {
        void Login(LoginRequest request);
        void Logout();
    }

    public class AccountService : IAccountService
    {
        private readonly IUserRepo userRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountService(IUserRepo userRepo, IHttpContextAccessor httpContextAccessor)
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

        public void Logout()
        {
            httpContextAccessor.HttpContext.Session.SetString(SessionKeys.UserSessionKey, "");
        }
    }
}