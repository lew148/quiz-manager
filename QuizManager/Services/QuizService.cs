using System.Collections.Generic;
using System.Linq;
using quizManager.Data.Models;
using quizManager.Data.Repos;
using quizManager.QuizManager.Requests;
using quizManager.QuizManager.Responses;

namespace quizManager.QuizManager.Services
{
    public interface IQuizService
    {
        public IEnumerable<QuizListResponse> GetAllQuizzes();
        public Quiz GetQuiz(int id);
        public void AddQuiz(AddQuizRequest request);
        public void DeleteQuiz(int quizId);
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
            var quizzes = quizRepo.GetAllQuizzes().ToList();
            
            GeneralHelpers.ThrowIfAnyAreNull(quizzes);
            
            return quizzes.Select(q => new QuizListResponse
            {
                Id = q.Id,
                Description = q.Description,
                Name = q.Name
            });
        }

        public Quiz GetQuiz(int id)
        {
            var quiz = quizRepo.GetQuizById(id);
            GeneralHelpers.ThrowIfNull(quiz);
            return quiz;
        }

        public void AddQuiz(AddQuizRequest request)
        {
            quizRepo.AddQuiz(new Quiz
            {
                Name = request.Name,
                Description = request.Description
            });
        }

        public void DeleteQuiz(int quizId)
        {
            var subjectQuiz = quizRepo.GetQuizById(quizId);
            GeneralHelpers.ThrowIfNull(subjectQuiz);
            quizRepo.DeleteQuiz(subjectQuiz);
        }
    }
}