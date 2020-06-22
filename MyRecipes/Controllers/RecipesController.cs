using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Helpers;
using MyRecipes.Services.Interfaces;
using MyRecipes.ViewModels;
using System;
using System.Linq;

namespace MyRecipes.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class RecipesController : Controller
    {
        public IRecipesService RecipesService { get; set; }
        public ILogsService LogsService { get; }

        public RecipesController(IRecipesService recipesService, ILogsService logsService)
        {
            RecipesService = recipesService;
            LogsService = logsService;
        }

        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            LogsService.Log("Overview", "Overview requested");

            var recipeOverviewData = new RecipeOverviewDataModel();
            var recipes = RecipesService.GetByTitle(title);

            var overviewViewModels = recipes
                    .Select(x => ModelConverter.ConvertToOverviewModel(x))
                    .ToList();

            var sidebarData = RecipesService.GetSidebarData();

            recipeOverviewData.Recipes = overviewViewModels;
            recipeOverviewData.SidebarData = sidebarData;

            return View(recipeOverviewData);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var recipe = RecipesService.GetRecipeDetails(id);
            var sidebarData = RecipesService.GetSidebarData();

            var recipeDetails = ModelConverter.ConvertToRecipeDetailsModel(recipe);
            recipeDetails.SidebarData = sidebarData;

            if (User.Identity.IsAuthenticated)
            {
                var userId = Convert.ToInt32(User.FindFirst("Id").Value);
                var currentLike = recipeDetails.RecipeLikes.FirstOrDefault(x => x.UserId == userId);

                if (currentLike != null)
                {
                    if (currentLike.Status)
                    {
                        recipeDetails.LikeStatus = RecipeLikeStatus.Liked;
                    }
                    else
                    {
                        recipeDetails.LikeStatus = RecipeLikeStatus.Disliked;
                    }
                }
            }

            return View(recipeDetails);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var recipe = new RecipeCreateModel();
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Create(RecipeCreateModel createRecipe)
        {
            if (ModelState.IsValid)
            {
                var recipe = ModelConverter.ConvertFromCreateModel(createRecipe);
                RecipesService.CreateRecipe(recipe);
                return RedirectToAction("ModifyOverview");
            }
            else
            {
                return View(createRecipe);
            }
        }

        public IActionResult ModifyOverview()
        {
            var recipes = RecipesService.GetAll();
            var modifyOverviewModels = recipes
                .Select(x => ModelConverter.ConverToModifyOverviewModel(x))
                .ToList();

            return View(modifyOverviewModels);
        }

        public IActionResult Delete(int id)
        {
            RecipesService.Delete(id);
            return RedirectToAction("ModifyOverview");
        }

        public IActionResult Modify(int id)
        {
            var recipe = RecipesService.GetById(id);
            var recipeModify = ModelConverter.ConvertToRecipeModify(recipe);
            return View(recipeModify);
        }

        [HttpPost]
        public IActionResult Modify(RecipeModifyModel modifyRecipe)
        {
            if (ModelState.IsValid)
            {
                var recipe = ModelConverter.ConvertFromRecipeModify(modifyRecipe);
                RecipesService.UpdateRecipe(recipe);
                return RedirectToAction("ModifyOverview");
            }

            return View(modifyRecipe);
        }
    }
}