using MyRecipes.Data;
using MyRecipes.Repository.Interfaces;

namespace MyRecipes.Repository
{
    public class LogsRepository : ILogsRepository
    {
        private MyRecipesContext Context { get; set; }

        public LogsRepository(MyRecipesContext context)
        {
            Context = context;
        }

        public void Add(Log log)
        {
            Context.Logs.Add(log);
            Context.SaveChanges();
        }
    }
}
