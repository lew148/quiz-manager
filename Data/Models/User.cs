namespace quizManager.Data.Models
{
    public enum Permission
    {
        Edit,
        View,
        Restricted
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Permission Permission { get; set; }
    }
}