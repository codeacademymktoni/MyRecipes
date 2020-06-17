using Microsoft.Extensions.Configuration;
using MyRecipes.Data;
using MyRecipes.Repository.Interfaces;
using MyRecipes.Services.DtoModels;
using MyRecipes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipes.Services
{
    public class RecipesService : IRecipesService
    {
        private IConfiguration Configuration { get; set; }

        public IRecipeRepository RecipesRepo { get; set; }

        public RecipesService(IRecipeRepository recipesRepo, IConfiguration configuration)
        {
            RecipesRepo = recipesRepo;
            this.Configuration = configuration;
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

        public Recipe GetRecipeDetails(int id)
        {
            var recipe = RecipesRepo.GetById(id);

            recipe.Views += 1;
            RecipesRepo.Update(recipe);

            return recipe;
        }

        public void CreateRecipe(Recipe recipe)
        {
            RecipesRepo.Add(recipe);
        }

        public List<Recipe> GetByTitle(string title)
        {
            var recipes = RecipesRepo.GetByTitle(title);
            return recipes;
        }

        public void Delete(int id)
        {
            RecipesRepo.Delete(id);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            RecipesRepo.Update(recipe);
        }

        public SidebarData GetSidebarData()
        {
            var recipes = RecipesRepo.GetAll();
            
            var topRecipes = recipes
                .OrderByDescending(x => x.Views)
                .Take(Convert.ToInt32(Configuration["SidebarRecipesCount"]))
                .Select(x => new SidebarRecipe() { 
                    Id = x.Id,
                    Title =x.Title,
                    DateCreated = x.DateCreated.Value,
                    Views = x.Views
                })
                .ToList();

            var recentRecipes = recipes
                .OrderByDescending(x => x.DateCreated)
                .Take(Convert.ToInt32(Configuration["SidebarRecipesCount"]))
                .Select(x => new SidebarRecipe()
                {
                    Id = x.Id,
                    Title = x.Title,
                    DateCreated = x.DateCreated.Value,
                    Views = x.Views
                })
                .ToList();

            var sidebarData = new SidebarData();
            sidebarData.TopRecipes = topRecipes;
            sidebarData.RecentRecipes = recentRecipes;

            return sidebarData;
        }
    }
}
