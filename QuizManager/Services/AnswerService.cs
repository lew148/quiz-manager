using System;
using quizManager.Data.Models;
using quizManager.Data.Repos;
using quizManager.QuizManager.Requests;

namespace quizManager.QuizManager.Services
{
    public interface IAnswerService
    {
        public void AddAnswer(AddAnswerRequest request);
        public void DeleteAnswer(int answerId);
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

        public void DeleteAnswer(int answerId)
        {
            var answer = answerRepo.GetAnswerById(answerId);
            
            if (answer == null)
            {
                throw new Exception("Answer does not exist");
            }
            
            answerRepo.DeleteAnswer(answer);
        }
    }
}