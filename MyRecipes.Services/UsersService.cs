using MyRecipes.Data;
using MyRecipes.Repository.Interfaces;
using MyRecipes.Services.DtoModels;
using MyRecipes.Services.Interfaces;
using System.Collections.Generic;

namespace MyRecipes.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public void Delete(int id)
        {
            usersRepository.Delete(id);
        }

        public List<User> GetAll()
        {
            return usersRepository.GetAll();
        }

        public User GetById(int id)
        {
            return usersRepository.GetById(id);
        }

        public ModifyUserResult ModifyUser(User user)
        {
            var result = new ModifyUserResult();

            var currentUser = usersRepository.GetByUsername(user.Username);

            if (currentUser == null || currentUser.Id == user.Id)
            {
                var dbUser = usersRepository.GetById(user.Id);

                dbUser.IsAdmin = user.IsAdmin;
                dbUser.Username = user.Username;

                usersRepository.Update(dbUser);
                result.Status = true;
            }
            else
            {
                result.Status = false;
                result.Message = "User with same username already exists";
            }

            return result;
        }

        public void ChangePassword(int id, string password)
        {
            var user = usersRepository.GetById(id);
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
            usersRepository.Update(user);
        }

        public string CreateUser(string username, string password, bool isAdmin)
        {
            string message = null;

            var user = usersRepository.GetByUsername(username);

            if (user == null)
            {
                var newUser = new User();
                newUser.Username = username;
                newUser.Password = BCrypt.Net.BCrypt.HashPassword(password);
                newUser.IsAdmin = isAdmin;

                usersRepository.Add(newUser);

                return message;
            }
            else
            {
                message = "User already exists";
                return message;
            }
        }

        public User GetByUsername(string username)
        {
            return usersRepository.GetByUsername(username);
        }
    }
}
