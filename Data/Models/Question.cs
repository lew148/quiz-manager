using System.Collections.Generic;

namespace quizManager.Data.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        
        public QuestionOrder QuestionOrder { get; set; }

        public List<Answer> Answers { get; set; }
    }
}