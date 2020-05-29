namespace quizManager.QuizManager.Requests
{
    public class AddAnswerRequest
    {
        public string Answer { get; set; }
        public int QuestionId { get; set; }
    }
}