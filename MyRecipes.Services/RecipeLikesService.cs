using MyRecipes.Data;
using MyRecipes.Repository.Interfaces;
using MyRecipes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipes.Services
{
    public class RecipeLikesService : IRecipeLikesService
    {
        private readonly IRecipeLikesRepository recipeLikesRepository;

        public RecipeLikesService(IRecipeLikesRepository recipeLikesRepository)
        {
            this.recipeLikesRepository = recipeLikesRepository;
        }
        public void AddLike(int recipeId, int userId)
        {
            var currentLike = recipeLikesRepository.Get(recipeId, userId);

            if (currentLike != null)
            {
                currentLike.Status = true;
                recipeLikesRepository.Update(currentLike);
            }
            else
            {
                var newLike = new RecipeLike();

                newLike.UserId = userId;
                newLike.RecipeId = recipeId;
                newLike.DateCreated = DateTime.Now;
                newLike.Status = true;

                recipeLikesRepository.Add(newLike);
            }
        }

        public void RemoveLike(int recipeId, int userId)
        {
            var like = recipeLikesRepository.Get(recipeId, userId);
            recipeLikesRepository.Remove(like);
        }
    }
}
