namespace quizManager.Data.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}