using MyRecipes.Models;
using MyRecipes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipes.Services
{
    public class RecipesService
    {
        public List<Recipe> GetAll()
        {
            var recipeRepository = new RecipeRepository();
            var recipes = recipeRepository.GetAll();
            return recipes;
        }

        public Recipe GetById(int id)
        {
            var recipeRepository = new RecipeRepository();
            var recipe = recipeRepository.GetById(id);
            return recipe;
        }
    }
}
