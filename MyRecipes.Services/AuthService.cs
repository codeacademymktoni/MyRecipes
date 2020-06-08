using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyRecipes.Data;
using MyRecipes.Repository.Interfaces;
using MyRecipes.Services.DtoModels;
using MyRecipes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyRecipes.Services
{
    public class AuthService : IAuthService
    {
        public AuthService(IUsersRepository usersRepo)
        {
            UsersRepo = usersRepo;
        }

        private IUsersRepository UsersRepo { get; set; }

        public async Task SignOutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        public async Task<bool> SignInAsync(string username, string password, HttpContext httpContext)
        {
            //get user from DB
            var user = UsersRepo.GetByUsername(username);

            //check if user exists and compare password
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                //create principal
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("IsAdmin", user.IsAdmin.ToString())
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                //sign in user to context
                await httpContext.SignInAsync(principal);

                return true;
            }

            return false;
        }

        public SignUpResponse SignUp(string username, string password)
        {
            var user = UsersRepo.GetByUsername(username);
            var response = new SignUpResponse();

            if(user == null)
            {
                var newUser = new User();
                newUser.Username = username;
                newUser.Password = BCrypt.Net.BCrypt.HashPassword(password);

                UsersRepo.Add(newUser);
                response.IsSuccessful = true;
                return response;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "User with username alreay exists";
                return response;
            }
        }
    }
}
