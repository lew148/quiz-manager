using System.Collections.Generic;
using System.Linq;
using quizManager.Data.Models;
using quizManager.Data.Repos;
using quizManager.QuizManager.Responses;

namespace quizManager.QuizManager.Services
{
    public interface IQuizService
    {
        public IEnumerable<QuizListResponse> GetAllQuizzes();
        public Quiz GetQuiz(int id);
    }

    public class QuizService : IQuizService
    {
        private readonly IQuizRepo quizRepo;

        public QuizService(IQuizRepo quizRepo)
        {
            this.quizRepo = quizRepo;
        }

        public IEnumerable<QuizListResponse> GetAllQuizzes()
        {
            return quizRepo.GetAllQuizzes().Select(q => new QuizListResponse
            {
                Id = q.Id,
                Description = q.Description,
                Name = q.Name
            });
        }

        public Quiz GetQuiz(int id)
        {
            return quizRepo.GetQuiz(id);
        }
    }
}