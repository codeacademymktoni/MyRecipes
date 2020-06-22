using MyRecipes.Data;
using MyRecipes.ViewModels;
using System;
using System.Linq;

namespace MyRecipes.Helpers
{
    public static class ModelConverter
    {
        public static RecipeOverviewModel ConvertToOverviewModel(Recipe recipe)
        {
            var overviewModel = new RecipeOverviewModel()
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                DaysCreated = DateTime.Now.Subtract(recipe.DateCreated.Value).Days
            };

            return overviewModel;
        }

        public static RecipeDetailsModel ConvertToRecipeDetailsModel(Recipe recipe)
        {
            return new RecipeDetailsModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Ingredients = recipe.Ingredients,
                Directions = recipe.Directions,
                DateCreated = recipe.DateCreated,
                Views = recipe.Views,
                RecipeComments = recipe.RecipeComments.Select(x => ConvertToRecipeCommentModel(x)).ToList(),
                RecipeLikes = recipe.RecipeLikes.Select(x => ConvertToRecipeLikesViewModel(x)).ToList()
            };
        }

        private static RecipeLikeModel ConvertToRecipeLikesViewModel(RecipeLike x)
        {
            return new RecipeLikeModel
            {
                Id = x.Id,
                DateCreated = x.DateCreated,
                Status = x.Status,
                UserId = x.UserId,
                RecipeId = x.RecipeId
            };
        }

        public static UserModifyModel ConvertToUserModifyModel(User user)
        {
            return new UserModifyModel
            {
                Id = user.Id,
                Username = user.Username,
                IsAdmin = user.IsAdmin,
            };
        }

        public static User ConvertFromUserModifyModel(UserModifyModel userModifyModel)
        {
            return new User
            {
                Id = userModifyModel.Id,
                IsAdmin = userModifyModel.IsAdmin,
                Username = userModifyModel.Username
            };
        }

        public static RecipeCommentModel ConvertToRecipeCommentModel(RecipeComment recipeComment)
        {
            return new RecipeCommentModel
            {
                Comment = recipeComment.Comment,
                DateCreated = recipeComment.DateCreated,
                Username = recipeComment.User.Username
            };
        }

        public static Recipe ConvertFromCreateModel(RecipeCreateModel createRecipe)
        {
            return new Recipe
            {
                Title = createRecipe.Title,
                Description = createRecipe.Description,
                ImageUrl = createRecipe.ImageUrl,
                Ingredients = createRecipe.Ingredients,
                Directions = createRecipe.Directions,
            };
        }

        public static RecipeModifyModel ConvertToRecipeModify(Recipe recipe)
        {
            return new RecipeModifyModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Ingredients = recipe.Ingredients,
                Directions = recipe.Directions,
                DateCreated = recipe.DateCreated,
                Views = recipe.Views
            };
        }

        public static ModifyOverviewModel ConverToModifyOverviewModel(Recipe recipe)
        {
            return new ModifyOverviewModel
            {
                Id = recipe.Id,
                Title = recipe.Title
            };
        }

        internal static UserDetailsModel ConvertToUserDetailsModel(User user)
        {
            return new UserDetailsModel
            {
                Id = user.Id,
                Username = user.Username,
                IsAdmin = user.IsAdmin
            };
        }

        public static Recipe ConvertFromRecipeModify(RecipeModifyModel recipe)
        {
            return new Recipe
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Ingredients = recipe.Ingredients,
                Directions = recipe.Directions,
                DateCreated = recipe.DateCreated,
                Views = recipe.Views
            };
        }

        public static ModifyUserOverviewModel ConvertToModifyUserOverview(User user)
        {
            return new ModifyUserOverviewModel
            {
                Id = user.Id,
                Username = user.Username,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
