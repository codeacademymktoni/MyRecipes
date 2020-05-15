using MyRecipes.Models;
using MyRecipes.Repository.Interfaces;
using MyRecipes.Services.Interfaces;
using System.Collections.Generic;

namespace MyRecipes.Services
{
    public class RecipesService : IRecipesService
    {
        public IRecipeRepository RecipesRepo{ get; set; }

        public RecipesService(IRecipeRepository recipesRepo)
        {
            RecipesRepo = recipesRepo;
        }

        public List<Recipe> GetAll()
        {
            var recipes = RecipesRepo.GetAll();
            return recipes;
        }

        public Recipe GetById(int id)
        {
            var recipe = RecipesRepo.GetById(id);
            return recipe;
        }
    }
}
