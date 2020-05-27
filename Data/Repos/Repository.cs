using Microsoft.EntityFrameworkCore;

namespace quizManager.Data.Repos
{
    public interface IRepository<in TObject> { }
    
    public class Repository<TObject> : IRepository<TObject> where TObject : class
    {
        protected readonly QuizManagerContext context;
        protected readonly DbSet<TObject> objects;

        public Repository()
        {
            context = new QuizManagerContext();
            objects = context.Set<TObject>();
        }
    }
}