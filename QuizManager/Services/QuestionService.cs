using System.Collections.Generic;
using System.Linq;
using quizManager.Data.Models;
using quizManager.Data.Repos;
using quizManager.QuizManager.Requests;

namespace quizManager.QuizManager.Services
{
    public interface IQuestionService
    {
        public void AddQuestion(AddQuestionRequest request);
        public void DeleteQuestion(int questionId);
        public void EditQuestion(int questionId, EditRequest request);
    }

    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepo questionRepo;
        private readonly IQuestionOrderService questionOrderService;

        public QuestionService(IQuestionRepo questionRepo, IQuestionOrderService questionOrderService)
        {
            this.questionRepo = questionRepo;
            this.questionOrderService = questionOrderService;
        }

        public void AddQuestion(AddQuestionRequest request)
        {
            GeneralHelpers.ThrowIfNull(request.Question);

            var initialAnswerDescriptions = new List<string>
            {
                request.InitialAnswerOne,
                request.InitialAnswerTwo,
                request.InitialAnswerThree
            };

            GeneralHelpers.ThrowIfAnyAreNull(initialAnswerDescriptions);

            var initialAnswers = initialAnswerDescriptions
                .Select(ad => new Answer
                {
                    Description = ad
                }).ToList();

            if (request.OrderPosition == -1) // question is last
            {
                AddQuestionToLastPositionOfQuiz(request.Question, initialAnswers, request.QuizId);
            }
            else
            {
                AddQuestionToSpecificPositionOfQuiz(request.Question, initialAnswers, request.QuizId,
                    request.OrderPosition);
            }
        }

        public void DeleteQuestion(int questionId)
        {
            var question = questionRepo.GetQuestionById(questionId);

            GeneralHelpers.ThrowIfNull(question);

            if (questionOrderService.GetBiggestQuestionOrderNumberForQuiz(question.QuizId)
                != question.QuestionOrder.Id) // question is not last
            {
                questionOrderService.UpdateQuestionOrdersForQuiz(question.QuizId, question.QuestionOrder.OrderNumber,
                    QuestionOrderUpdateType.RemovingQuestion);
            }

            questionRepo.DeleteQuestion(question);
        }

        public void EditQuestion(int questionId, EditRequest request)
        {
            var subjectQuestion = questionRepo.GetQuestionById(questionId);
            
            GeneralHelpers.ThrowIfNull(subjectQuestion);

            subjectQuestion.Description = request.NewDescription;
            
            questionRepo.EditQuestion(subjectQuestion);
        }

        private void AddQuestionToLastPositionOfQuiz(string question, List<Answer> initialAnswers, int quizId)
        {
            var orderPosition = 0; // default for is there are no questions in quiz already

            if (questionRepo.GetNumberOfQuestionsInQuiz(quizId) != 0)
            {
                var biggestQuestionOrderNumberForQuiz =
                    questionOrderService.GetBiggestQuestionOrderNumberForQuiz(quizId);
                orderPosition = biggestQuestionOrderNumberForQuiz + 1;
            }

            AddQuestionWithParams(question, initialAnswers, quizId, orderPosition);
        }

        private void AddQuestionToSpecificPositionOfQuiz(string question, List<Answer> initialAnswers, int quizId,
            int orderPosition)
        {
            questionOrderService.UpdateQuestionOrdersForQuiz(quizId, orderPosition,
                QuestionOrderUpdateType.AddingQuestion);
            AddQuestionWithParams(question, initialAnswers, quizId, orderPosition);
        }

        private void AddQuestionWithParams(string question, List<Answer> initialAnswers, int quizId, int orderPosition)
        {
            questionRepo.AddQuestion(new Question
            {
                Description = question,
                QuizId = quizId,
                QuestionOrder = new QuestionOrder
                {
                    OrderNumber = orderPosition
                },
                Answers = initialAnswers
            });
        }
    }
}