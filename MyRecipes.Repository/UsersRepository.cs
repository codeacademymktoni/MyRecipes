using MyRecipes.Data;
using MyRecipes.Repository.Interfaces;
using System.Collections.Generic;
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

        public List<User> GetAll()
        {
            return Context.Users.ToList();
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

        public void Delete(int id)
        {
            var user = new User()
            {
                Id = id
            };

            Context.Remove(user);
            Context.SaveChanges();
        }

        public User GetById(int id)
        {
            return Context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User dbUser)
        {
            Context.Users.Update(dbUser);
            Context.SaveChanges();
        }
    }
}
    