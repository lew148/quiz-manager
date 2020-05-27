using System.Linq;
using quizManager.Data.Models;
using quizManager.Data.Requests;

namespace quizManager.Data.Repos
{
    public interface IUserRepo
    {
        public User LoginUser(string username, string password);
    }

    public class UserRepo : Repository<User>, IUserRepo
    {
        public User LoginUser(string username, string password)
        {
            var userWithUsername = objects.Single(u => u.Username.Equals(username) && u.Password.Equals(password));
            return userWithUsername;
        }
    }
}