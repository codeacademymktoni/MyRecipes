using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Data;
using MyRecipes.Helpers;
using MyRecipes.Services.Interfaces;
using MyRecipes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipes.Controllers
{
    [Authorize]
    public class RecipesController : Controller
    {
        public IRecipesService RecipesService { get; set; }

        public RecipesController(IRecipesService recipesService)
        {
            RecipesService = recipesService;
        }

        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            var recipes = RecipesService.GetByTitle(title);

            var overviewViewModels = recipes
                    .Select(x => ModelConverter.ConvertToOverviewModel(x))
                    .ToList();

            return View(overviewViewModels);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var recipe = RecipesService.GetRecipeDetails(id);

            var recipeDetails = ModelConverter.ConvertToRecipeDetailsModel(recipe);

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