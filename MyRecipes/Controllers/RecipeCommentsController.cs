using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Services.Interfaces;
using System;

namespace MyRecipes.Controllers
{
    public class RecipeCommentsController : Controller
    {
        public RecipeCommentsController(IRecipeCommentsService recipeCommentsService)
        {
            RecipeCommentsService = recipeCommentsService;
        }

        public IRecipeCommentsService RecipeCommentsService { get; }


        [Authorize]
        public IActionResult Add(string comment, int recipeId)
        {
            if (!String.IsNullOrEmpty(comment))
            {
                var userId = Convert.ToInt32(User.FindFirst("Id").Value);
                RecipeCommentsService.Add(comment, recipeId, userId);
            }
            return RedirectToAction("Details", "Recipes", new { id = recipeId });
        }
    }
}