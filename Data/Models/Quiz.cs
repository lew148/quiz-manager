using System.Collections.Generic;

namespace quizManager.Data.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Question> Questions { get; set; }
    }
}