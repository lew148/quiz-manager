using System.Linq;
using quizManager.Data.Repos;

namespace quizManager.QuizManager.Services
{
    public interface IQuestionOrderService
    {
        public void UpdateQuestionOrdersForQuiz(int quizId, int orderPosition);
        public int GetBiggestQuestionOrderNumberForQuiz(int quizId);
    }

    public class QuestionOrderService : IQuestionOrderService
    {
        private readonly IQuestionOrderRepo questionOrderRepo;

        public QuestionOrderService(IQuestionOrderRepo questionOrderRepo)
        {
            this.questionOrderRepo = questionOrderRepo;
        }


        public void UpdateQuestionOrdersForQuiz(int quizId, int orderPosition)
        {
            var existingQuestionOrders =
                questionOrderRepo.GetAllOrdersForQuizGreaterThanOrEqualToPosition(quizId, orderPosition);
            
            var updatedQuestionOrders = existingQuestionOrders.Select(qo =>
            {
                qo.OrderNumber++;
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