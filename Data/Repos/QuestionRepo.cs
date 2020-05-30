using System.Linq;
using Microsoft.EntityFrameworkCore;
using quizManager.Data.Models;

namespace quizManager.Data.Repos
{
    public interface IQuestionRepo
    {
        public void AddQuestion(Question question);
        public int GetNumberOfQuestionsInQuiz(int quizId);
        public void DeleteQuestion(Question question);
        public Question GetQuestionById(int questionId);
        public void EditQuestion(Question question);
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

        public void DeleteQuestion(Question question)
        {
            Context.Remove(question);
            Context.SaveChanges();
        }

        public Question GetQuestionById(int questionId)
        {
            return Objects
                .Include(q => q.QuestionOrder)
                .SingleOrDefault(q => q.Id == questionId);
        }

        public void EditQuestion(Question question)
        {
            Context.Update(question);
            Context.SaveChanges();
        }
    }
}