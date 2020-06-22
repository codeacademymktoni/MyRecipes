using MyRecipes.Data;
using MyRecipes.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRecipes.Repository
{
 

    public class RecipeLikesRepository : IRecipeLikesRepository
    {
        private MyRecipesContext Context { get; set; }

        public RecipeLikesRepository(MyRecipesContext context)
        {
            Context = context;
        }

        public void Add(RecipeLike like)
        {
            Context.RecipeLikes.Add(like);
            Context.SaveChanges();
        }

        public RecipeLike Get(int recipeId, int userId)
        {
            return Context.RecipeLikes.FirstOrDefault(x => x.RecipeId == recipeId && x.UserId == userId);
        }

        public void Remove(RecipeLike like)
        {
            Context.RecipeLikes.Remove(like);
            Context.SaveChanges();
        }

        public void Update(RecipeLike currentLike)
        {
            Context.RecipeLikes.Update(currentLike);
            Context.SaveChanges();
        }
    }
}
