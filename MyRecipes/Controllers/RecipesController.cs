using Microsoft.AspNetCore.Mvc;
using MyRecipes.Data;
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

        public IActionResult Overview(string title)
        {
            var recipes = RecipesService.GetByTitle(title);

            return View(recipes);
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
                return RedirectToAction("Overview");
            }
            else
            {
                return View(recipe);
            }
        }
    }
}