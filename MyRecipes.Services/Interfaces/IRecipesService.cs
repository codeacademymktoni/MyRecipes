using MyRecipes.Models;
using System.Collections.Generic;

namespace MyRecipes.Services.Interfaces
{
    public interface IRecipesService
    {
        List<Recipe> GetAll();
        List<Recipe> GetByTitle(string title);
        Recipe GetById(int id);
        void CreateRecipe(Recipe recipe);
    }
}
