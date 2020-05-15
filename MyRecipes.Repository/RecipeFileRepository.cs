using MyRecipes.Models;
using MyRecipes.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyRecipes.Repository
{
    public class RecipeFileRepository : IRecipeRepository
    {
        public List<Recipe> Recipes { get; set; }

        public RecipeFileRepository()
        {
            var recipes = File.ReadAllText("recipes.txt");

            Recipes = JsonConvert.DeserializeObject<List<Recipe>>(recipes);
        }

        public List<Recipe> GetAll()
        {
            return Recipes;
        }

        public Recipe GetById(int id)
        {
            return Recipes.FirstOrDefault(x => x.Id == id);
        }
    }
}
