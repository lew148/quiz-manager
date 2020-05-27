using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using quizManager.Data.Repos;
using quizManager.Data.Requests;
using quizManager.Data.SessionModels;
using quizManager.Shared.Constants;

namespace quizManager.Data.Services
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
            var user = userRepo.LoginUser(request.Username, request.Password);

            if (user != null) // single user with username and password exist
            {
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
}