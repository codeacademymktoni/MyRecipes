using MyRecipes.Data;
using System.Collections.Generic;

namespace MyRecipes.Repository.Interfaces
{
    public interface IUsersRepository
    {
        User GetByUsername(string username);
        void Add(User user);
        List<User> GetAll();
        void Delete(int id);
        User GetById(int id);
        void Update(User dbUser);
    }
}
