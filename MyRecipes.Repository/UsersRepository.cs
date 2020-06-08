using MyRecipes.Data;
using MyRecipes.Repository.Interfaces;
using System.Linq;

namespace MyRecipes.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private MyRecipesContext Context { get; set; }

        public UsersRepository(MyRecipesContext context)
        {
            Context = context;
        }

        public User GetByUsername(string username)
        {
            return Context.Users.FirstOrDefault(x => x.Username == username);
        }

        public void Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
    