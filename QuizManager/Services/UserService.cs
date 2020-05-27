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
    public interface IUserService
    {
        void Login(LoginRequest request);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(IUserRepo userRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.userRepo = userRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void Login(LoginRequest request)
        {
            var user = userRepo.GetUserByUsername(request.Username);

            if (user == null || !Verify(request.Password, user.Password)) // single user with username and correct password doesnt exist
            {
                throw new Exception("User does not exist");
            }

            var userSessionModel = new UserSessionModel
            {
                Id = user.Id,
                LoggedIn = true,
                Permission = user.Permission
            };
                    
            httpContextAccessor.HttpContext.Session.SetString(SessionKeys.UserSessionKey, JsonConvert.SerializeObject(userSessionModel));
        }
    }
}