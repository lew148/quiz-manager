using System;
using System.Collections.Generic;
using quizManager.Data.Models;
using quizManager.Data.Repos;
using quizManager.QuizManager.Requests;

namespace quizManager.QuizManager.Services
{
    public interface IQuestionService
    {
        public void AddQuestion(AddQuestionRequest request);
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
            if (request.Question == null)
            {
                throw new Exception("Question is null");
            }

            if (request.InitialAnswerOne == null || 
                request.InitialAnswerTwo == null ||
                request.InitialAnswerThree == null)
            {
                throw new Exception("One or more initial answers are null");
            }

            var initialAnswers = new List<Answer>
            {
                CreateAnswerObject(request.InitialAnswerOne),
                CreateAnswerObject(request.InitialAnswerTwo),
                CreateAnswerObject(request.InitialAnswerThree)
            };
            
            if (request.OrderPosition == -1) // last
            {
                AddQuestionToLastPositionOfQuiz(request.Question, initialAnswers, request.QuizId);
            }
            else
            {
                AddQuestionToSpecificPositionOfQuiz(request.Question, initialAnswers, request.QuizId, request.OrderPosition);
            }
        }

        private void AddQuestionToLastPositionOfQuiz(string question, List<Answer> initialAnswers, int quizId)
        {
            var orderPosition = 0; // default for is there are no questions in quiz already
            
            if (questionRepo.GetNumberOfQuestionsInQuiz(quizId) != 0)
            {
                var biggestQuestionOrderNumberForQuiz = questionOrderService.GetBiggestQuestionOrderNumberForQuiz(quizId);
                orderPosition = biggestQuestionOrderNumberForQuiz + 1;
            }

            AddQuestionWithParams(question, initialAnswers, quizId, orderPosition);
        }

        private void AddQuestionToSpecificPositionOfQuiz(string question, List<Answer> initialAnswers, int quizId, int orderPosition)
        {
            questionOrderService.UpdateQuestionOrdersForQuiz(quizId, orderPosition);
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

        private Answer CreateAnswerObject(string answerDescription)
        {
            return new Answer
            {
                Description = answerDescription
            };
        }
    }
}