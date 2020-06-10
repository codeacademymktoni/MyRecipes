using MyRecipes.Data;
using MyRecipes.Services.DtoModels;
using System.Collections.Generic;

namespace MyRecipes.Services.Interfaces
{
    public interface IRecipesService
    {
        List<Recipe> GetAll();
        List<Recipe> GetByTitle(string title);
        Recipe GetById(int id);
        void CreateRecipe(Recipe recipe);
        Recipe GetRecipeDetails(int id);
        void Delete(int id);
        void UpdateRecipe(Recipe recipe);
        SidebarData GetSidebarData();
    }
}
