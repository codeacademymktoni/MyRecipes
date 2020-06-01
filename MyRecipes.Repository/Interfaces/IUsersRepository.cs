using MyRecipes.Data;

namespace MyRecipes.Repository.Interfaces
{
    public interface IUsersRepository
    {
        User GetByUsername(string username);
    }
}
