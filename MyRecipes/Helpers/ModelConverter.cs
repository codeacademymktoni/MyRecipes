using MyRecipes.Data;
using MyRecipes.ViewModels;
using System;

namespace MyRecipes.Helpers
{
    public static class ModelConverter
    {
        public static OverviewViewModel ConvertToOverviewModel(Recipe recipe)
        {
            var overviewModel = new OverviewViewModel()
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                DaysCreated = DateTime.Now.Subtract(recipe.DateCreated.Value).Days
            };

            return overviewModel;
        }
    }
}
