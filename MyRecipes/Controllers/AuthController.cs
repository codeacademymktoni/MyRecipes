using Microsoft.AspNetCore.Mvc;
using MyRecipes.Services.Interfaces;
using MyRecipes.ViewModels;
using System;
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
        public async Task<IActionResult> SignIn(SignInModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var isSignedIn = await AuthService.SignInAsync(model.Username, model.Password, HttpContext);

                if (isSignedIn)
                {
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Overview", "Recipes");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                    return View(model);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
            await AuthService.SignOutAsync(HttpContext);
            return RedirectToAction("Overview", "Recipes");
        }

        public IActionResult SignUp()
        {
            var signUpModel = new SignUpModel();
            return View(signUpModel);
        }

        [HttpPost]
        public IActionResult SignUp(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var response = AuthService.SignUp(signUpModel.Username, signUpModel.Password);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, response.Message);
                    return View(signUpModel);
                }

            }

            return View(signUpModel);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}