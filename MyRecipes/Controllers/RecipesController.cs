using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Services;

namespace MyRecipes.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Overview()
        {
            var service = new RecipesService();
            var recipes = service.GetAll();

            return View(recipes);
        }

        public IActionResult Details(int id)
        {
            var service = new RecipesService();
            var recipe = service.GetById(id);

            return View(recipe);
        }
    }
}