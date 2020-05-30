using System.Linq;
using quizManager.Data.Models;
using quizManager.Data.Repos;

namespace quizManager.QuizManager.Services
{
    public enum QuestionOrderUpdateType {
        AddingQuestion,
        RemovingQuestion
    }

    public interface IQuestionOrderService
    {
        public void UpdateQuestionOrdersForQuiz(int quizId, int orderPosition, QuestionOrderUpdateType updateType);
        public int GetBiggestQuestionOrderNumberForQuiz(int quizId);
    }

    public class QuestionOrderService : IQuestionOrderService
    {
        private readonly IQuestionOrderRepo questionOrderRepo;

        public QuestionOrderService(IQuestionOrderRepo questionOrderRepo)
        {
            this.questionOrderRepo = questionOrderRepo;
        }


        public void UpdateQuestionOrdersForQuiz(int quizId, int orderPosition, QuestionOrderUpdateType updateType)
        {
            var existingQuestionOrders =
                questionOrderRepo.GetAllOrdersForQuizGreaterThanOrEqualToPosition(quizId, orderPosition);

            var updatedQuestionOrders = existingQuestionOrders.Select(qo =>
            {
                switch (updateType)
                {
                    case QuestionOrderUpdateType.AddingQuestion:
                        qo.OrderNumber++;
                        break;
                    case QuestionOrderUpdateType.RemovingQuestion:
                        qo.OrderNumber--;
                        break;
                }
                return qo;
            }).ToList(); // to list is required to stop evaluation weirdness
            
            questionOrderRepo.BulkUpdateQuestionOrder(updatedQuestionOrders);
        }

        public int GetBiggestQuestionOrderNumberForQuiz(int quizId)
        {
            return questionOrderRepo.GetBiggestQuestionOrderNumberForQuiz(quizId);
        }
    }
}