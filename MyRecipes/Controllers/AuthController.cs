using Microsoft.AspNetCore.Mvc;
using MyRecipes.Services.Interfaces;
using MyRecipes.ViewModels;
using System.Threading.Tasks;

namespace MyRecipes.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService AuthService { get; set; }

        public AuthController(IAuthService authService)
        {
            AuthService = authService;
        }

        public IActionResult SignIn()
        {
            var signInModel = new SignInModel();
            return View(signInModel);
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var isSignedIn = await AuthService.SignInAsync(model.Username, model.Password, HttpContext);

                if (isSignedIn)
                {
                    return RedirectToAction("Overview", "Recipes");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                    return View(model);
                }
            }

            return View(model);
        }
    }
}