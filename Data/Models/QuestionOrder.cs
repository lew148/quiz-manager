namespace quizManager.Data.Models
{
    public class QuestionOrder
    {
        public int Id { get; set; }
        
        // no quiz id (should use Quiz id assigned to question)

        public int QuestionId { get; set; }
        public Question Question { get; set; }
        
        public int OrderNumber { get; set; }
    }
}