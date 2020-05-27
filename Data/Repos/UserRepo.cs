using System;
using System.Linq;
using BCrypt.Net;
using Microsoft.AspNetCore.Server.IIS;
using quizManager.Data.Models;
using static BCrypt.Net.BCrypt;

namespace quizManager.Data.Repos
{
    public interface IUserRepo
    {
        public User GetUserByUsername(string username);
    }

    public class UserRepo : Repo<User>, IUserRepo
    {
        public User GetUserByUsername(string username)
        {
           return Objects.Single(u => u.Username.Equals(username));
        }
    }
}