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

        public IActionResult Create()
        {
            var recipe = new Recipe();
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            //call service to create new recipe;
            return RedirectToAction("Overview");
        }
    }
}