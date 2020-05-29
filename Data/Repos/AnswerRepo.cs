using quizManager.Data.Models;

namespace quizManager.Data.Repos
{
    public interface IAnswerRepo
    {
        public void AddAnswer(Answer answer);
    }

    public class AnswerRepo : Repo<Answer> , IAnswerRepo
    {
        public void AddAnswer(Answer answer)
        {
            Context.Add(answer);
            Context.SaveChanges();
        }
    }
}