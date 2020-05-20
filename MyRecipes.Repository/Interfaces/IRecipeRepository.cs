using MyRecipes.Models;
using System.Collections.Generic;

namespace MyRecipes.Repository.Interfaces
{
    public interface IRecipeRepository
    {
        List<Recipe> GetAll();
        List<Recipe> GetByTitle(string title);
        Recipe GetById(int id);
        void Add(Recipe recipe);
    }
}
