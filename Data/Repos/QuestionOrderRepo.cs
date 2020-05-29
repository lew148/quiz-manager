using System.Collections.Generic;
using System.Linq;
using quizManager.Data.Models;

namespace quizManager.Data.Repos
{
    public interface IQuestionOrderRepo
    {
        public void BulkUpdateQuestionOrder(IEnumerable<QuestionOrder> questionOrders);
        public IEnumerable<QuestionOrder> GetAllOrdersForQuizGreaterThanOrEqualToPosition(int quizId, int orderNumber);
        public int GetBiggestQuestionOrderNumberForQuiz(int quizId);
    }
    
    public class QuestionOrderRepo : Repo<QuestionOrder>, IQuestionOrderRepo
    {
        public void BulkUpdateQuestionOrder(IEnumerable<QuestionOrder> questionOrders)
        {
            Context.UpdateRange(questionOrders);
            Context.SaveChanges();
        }

        public IEnumerable<QuestionOrder> GetAllOrdersForQuizGreaterThanOrEqualToPosition(int quizId, int orderNumber)
        {
            return Objects
                .Where(qo => qo.Question.QuizId == quizId && qo.OrderNumber >= orderNumber);
        }

        public int GetBiggestQuestionOrderNumberForQuiz(int quizId)
        {
            return Objects
                .Where(qo => qo.Question.QuizId == quizId)
                .Select(qo => qo.OrderNumber)
                .Max();
        }
    }
}