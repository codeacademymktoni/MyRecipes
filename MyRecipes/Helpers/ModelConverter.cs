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
                RecipeComments = recipe.RecipeComments.Select(x => ConvertToRecipeCommentModel(x)).ToList()
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
    }
}
