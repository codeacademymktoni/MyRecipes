using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyRecipes.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(string username, string password, HttpContext httpContext);
    }
}
