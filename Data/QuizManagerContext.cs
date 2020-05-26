using Microsoft.EntityFrameworkCore;
using quizManager.Data.Models;

namespace quizManager.Data
{
    public class QuizManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=quiz_manager.db");
    }
}