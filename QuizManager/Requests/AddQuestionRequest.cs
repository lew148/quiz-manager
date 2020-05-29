namespace quizManager.QuizManager.Requests
{
    public class AddQuestionRequest
    {
        public int QuizId { get; set; }
        public string Question { get; set; }
        public int OrderPosition { get; set; }
    }
}