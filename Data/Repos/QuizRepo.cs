using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using quizManager.Data.Models;

namespace quizManager.Data.Repos
{
    public interface IQuizRepo
    {
        public IEnumerable<Quiz> GetAllQuizzes();
        public Quiz GetQuizById(int id);
        public void AddQuiz(Quiz quiz);
        public void DeleteQuiz(Quiz quiz);
    }

    public class QuizRepo : Repo<Quiz>, IQuizRepo
    {
        public IEnumerable<Quiz> GetAllQuizzes()
        {
            return Objects;
        }

        public Quiz GetQuizById(int id)
        {
            return Objects
                .Include(quiz => quiz.Questions).ThenInclude(question => question.Answers)
                .Include(quiz => quiz.Questions).ThenInclude(question => question.QuestionOrder)
                .SingleOrDefault(q => q.Id == id);
        }

        public void AddQuiz(Quiz quiz)
        {
            Context.Add(quiz);
            Context.SaveChanges();
        }

        public void DeleteQuiz(Quiz quiz)
        {
            Context.Remove(quiz);
            Context.SaveChanges();
        }
    }
}