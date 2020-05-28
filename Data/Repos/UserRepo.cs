using System.Linq;
using quizManager.Data.Models;

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