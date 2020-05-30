using quizManager.Data.Models;
using quizManager.Data.Repos;
using quizManager.QuizManager.Requests;

namespace quizManager.QuizManager.Services
{
    public interface IAnswerService
    {
        public void AddAnswer(AddAnswerRequest request);
        public void DeleteAnswer(int answerId);
        public void EditAnswer(int answerId, EditRequest request);
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
            GeneralHelpers.ThrowIfNull(request.Answer);
            answerRepo.AddAnswer(new Answer
            {
                Description = request.Answer,
                QuestionId = request.QuestionId
            });
        }

        public void DeleteAnswer(int answerId)
        {
            var answer = answerRepo.GetAnswerById(answerId);
            GeneralHelpers.ThrowIfNull(answer);
            answerRepo.DeleteAnswer(answer);
        }

        public void EditAnswer(int answerId, EditRequest request)
        {
            var subjectAnswer = answerRepo.GetAnswerById(answerId);
            
            GeneralHelpers.ThrowIfNull(subjectAnswer);

            subjectAnswer.Description = request.NewDescription;
            
            answerRepo.EditAnswer(subjectAnswer);
        }
    }
}