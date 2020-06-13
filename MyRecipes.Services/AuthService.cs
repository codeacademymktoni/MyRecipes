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
        public AuthService(IUsersService usersService)
        {
            UsersService = usersService;
        }

        private IUsersService UsersService { get; set; }

        public async Task SignOutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        public async Task<bool> SignInAsync(string username, string password, HttpContext httpContext)
        {
            //get user from DB
            var user = UsersService.GetByUsername(username);

            //check if user exists and compare password
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                //create principal
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("IsAdmin", user.IsAdmin.ToString()),
                    new Claim("Id", user.Id.ToString())
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
            var response = new SignUpResponse();
            var createUserResult = UsersService.CreateUser(username, password, false);

            if(createUserResult  == null)
            {
                response.IsSuccessful = true;
            }
            else
            {
                response.IsSuccessful = true;
                response.Message = createUserResult;
            }

            return response;
        }
    }
}
