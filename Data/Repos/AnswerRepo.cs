using System.Linq;
using quizManager.Data.Models;

namespace quizManager.Data.Repos
{
    public interface IAnswerRepo
    {
        public Answer GetAnswerById(int answerId);
        public void AddAnswer(Answer answer);
        public void DeleteAnswer(Answer answer);
    }

    public class AnswerRepo : Repo<Answer> , IAnswerRepo
    {
        public Answer GetAnswerById(int answerId)
        {
            return Objects.SingleOrDefault(a => a.Id == answerId);
        }

        public void AddAnswer(Answer answer)
        {
            Context.Add(answer);
            Context.SaveChanges();
        }

        public void DeleteAnswer(Answer answer)
        {
            Context.Remove(answer);
            Context.SaveChanges();
        }
    }
}