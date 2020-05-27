using quizManager.Data.Models;

namespace quizManager.Data.SessionModels
{
    public class UserSessionModel
    {
        public int Id { get; set; }
        public bool LoggedIn { get; set; }
        public Permission Permission { get; set; }
    }
}