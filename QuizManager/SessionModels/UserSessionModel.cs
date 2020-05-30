using quizManager.Data.Models;

namespace quizManager.QuizManager.SessionModels
{
    public class UserSessionModel
    {
        public int Id { get; set; }
        public Permission Permission { get; set; }
    }
}