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
    public class RecipesController : Controller
    {
        public IRecipesService RecipesService { get; set; }

        public RecipesController(IRecipesService recipesService)
        {
            RecipesService = recipesService;
        }

        public IActionResult Overview(string title)
        {
            var recipes = RecipesService.GetByTitle(title);

            var overviewViewModels = recipes
                    .Select(x => ModelConverter.ConvertToOverviewModel(x))
                    .ToList();

            return View(overviewViewModels);
        }

        public IActionResult Details(int id)
        {
            var recipe = RecipesService.GetRecipeDetails(id);

            return View(recipe);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var recipe = new Recipe();
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                RecipesService.CreateRecipe(recipe);
                return RedirectToAction("ModifyOverview");
            }
            else
            {
                return View(recipe);
            }
        }

        public IActionResult ModifyOverview()
        {
            var recipes = RecipesService.GetAll();
            return View(recipes);
        }

        public IActionResult Delete(int id)
        {
            RecipesService.Delete(id);
            return RedirectToAction("ModifyOverview");
        }

        public IActionResult Modify(int id)
        {
            var recipe = RecipesService.GetById(id);
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Modify(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                RecipesService.UpdateRecipe(recipe);
                return RedirectToAction("ModifyOverview");
            }

            return View(recipe);
        }
    }
}