using MyRecipes.Data;
using MyRecipes.Repository.Interfaces;
using MyRecipes.Services.Interfaces;
using System;

namespace MyRecipes.Services
{
    public class RecipeCommentsService : IRecipeCommentsService
    {
        public RecipeCommentsService(IRecipeCommentsRepository recipeCommentsRepository)
        {
            RecipeCommentsRepository = recipeCommentsRepository;
        }

        private IRecipeCommentsRepository RecipeCommentsRepository { get; }

        public void Add(string comment, int recipeId, int userId) 
        {
            var recipeComment = new RecipeComment();
            recipeComment.Comment = comment;
            recipeComment.RecipeId = recipeId;
            recipeComment.UserId = userId;
            recipeComment.DateCreated = DateTime.Now;

            RecipeCommentsRepository.Add(recipeComment);
        }
    }
}
