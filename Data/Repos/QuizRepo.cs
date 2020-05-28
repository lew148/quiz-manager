using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using quizManager.Data.Models;

namespace quizManager.Data.Repos
{
    public interface IQuizRepo
    {
        public IEnumerable<Quiz> GetAllQuizzes();
        public Quiz GetQuiz(int id);
    }

    public class QuizRepo : Repo<Quiz>, IQuizRepo
    {
        public IEnumerable<Quiz> GetAllQuizzes()
        {
            return Objects;
        }

        public Quiz GetQuiz(int id)
        {
            return Objects
                .Include(quiz => quiz.Questions)
                .ThenInclude(question => question.Answers)
                .Single(q => q.Id == id);
        }
    }
}