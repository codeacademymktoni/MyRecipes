using Microsoft.AspNetCore.Mvc;
using MyRecipes.Models;
using MyRecipes.Services.Interfaces;

namespace MyRecipes.Controllers
{
    public class RecipesController : Controller
    {
        public IRecipesService RecipesService { get; set; }

        public RecipesController(IRecipesService recipesService)
        {
            RecipesService = recipesService;
        }

        public IActionResult Overview()
        {
            var recipes = RecipesService.GetAll();

            return View(recipes);
        }

        public IActionResult Details(int id)
        {
            var recipe = RecipesService.GetById(id);

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
                return RedirectToAction("Overview");
            }
            else
            {
                return View(recipe);
            }
        }
    }
}