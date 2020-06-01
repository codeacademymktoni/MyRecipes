using MyRecipes.Data;
using MyRecipes.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
