using MyRecipes.Data;
using MyRecipes.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyRecipes.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private MyRecipesContext Context { get; set; }

        public RecipeRepository(MyRecipesContext context)
        {
            Context = context;
        }
        
        public void Add(Recipe recipe)
        {
            recipe.DateCreated = DateTime.Now;
            Context.Recipes.Add(recipe);
            Context.SaveChanges();
        }

        public List<Recipe> GetAll()
        {
            return Context.Recipes.ToList();
        }

        public Recipe GetById(int id)
        {
            return Context.Recipes.FirstOrDefault(x => x.Id == id);
        }

        public List<Recipe> GetByTitle(string title)
        {
            var recipes = Context.Recipes.AsQueryable();

            if (!String.IsNullOrEmpty(title))
            {
                recipes = recipes.Where(x => x.Title.Contains(title));
            }

            return recipes.ToList();
        }

        public void Update(Recipe recipe)
        {
            Context.Entry<Recipe>(recipe).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
