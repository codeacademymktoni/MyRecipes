using MyRecipes.Models;
using System.Collections.Generic;

namespace MyRecipes.Repository.Interfaces
{
    public interface IRecipeRepository
    {
        List<Recipe> GetAll();

        Recipe GetById(int id);
    }
}
