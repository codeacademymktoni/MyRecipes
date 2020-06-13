
using MyRecipes.Data;
using MyRecipes.Services.DtoModels;
using System.Collections.Generic;

namespace MyRecipes.Services.Interfaces
{
    public interface IUsersService
    {
        List<User> GetAll();
        void Delete(int id);
        User GetById(int id);
        User GetByUsername(string username);
        ModifyUserResult ModifyUser(User user);
        void ChangePassword(int id, string password);
        string CreateUser(string username, string password, bool isAdmin);
    }
}
