using System;
using quizManager.Data.Models;
using quizManager.Data.Repos;
using quizManager.QuizManager.Requests;

namespace quizManager.QuizManager.Services
{
    public interface IAnswerService
    {
        public void AddAnswer(AddAnswerRequest request);
    }

    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepo answerRepo;

        public AnswerService(IAnswerRepo answerRepo)
        {
            this.answerRepo = answerRepo;
        }

        public void AddAnswer(AddAnswerRequest request)
        {
            if (request.Answer == null)
            {
                throw new Exception("Answer is null");
            }

            answerRepo.AddAnswer(new Answer
            {
                Description = request.Answer,
                QuestionId = request.QuestionId
            });
        }
    }
}