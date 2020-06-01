using Microsoft.AspNetCore.Mvc;
using MyRecipes.ViewModels;

namespace MyRecipes.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignIn()
        {
            var signInModel = new SignInModel();
            return View(signInModel);
        }


        [HttpPost]
        public IActionResult SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                //sign in user

                return RedirectToAction("Overview", "Recipes");
            }

            return View(model);
        }
    }
}