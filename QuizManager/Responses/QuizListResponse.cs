namespace quizManager.QuizManager.Responses
{
    public class QuizListResponse
    {
        // omitting Questions property for performance
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}