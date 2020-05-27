using Microsoft.EntityFrameworkCore;

namespace quizManager.Data.Repos
{
    public interface IRepo<in TObject> { }
    
    public class Repo<TObject> : IRepo<TObject> where TObject : class
    {
        protected readonly QuizManagerContext Context;
        protected readonly DbSet<TObject> Objects;

        public Repo()
        {
            Context = new QuizManagerContext();
            Objects = Context.Set<TObject>();
        }
    }
}