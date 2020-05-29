using System.Linq;
using quizManager.Data.Models;

namespace quizManager.Data.Repos
{
    public interface IQuestionRepo
    {
        public void AddQuestion(Question question);
        public int GetNumberOfQuestionsInQuiz(int quizId);
    }

    public class QuestionRepo : Repo<Question>, IQuestionRepo
    {
        public void AddQuestion(Question question)
        {
            Context.Add(question);
            Context.SaveChanges();
        }

        public int GetNumberOfQuestionsInQuiz(int quizId)
        {
            return Objects
                .Count(q => q.QuizId == quizId);
        }
    }
}