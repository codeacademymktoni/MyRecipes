using MyRecipes.Models;
using System.Collections.Generic;

namespace MyRecipes.Services.Interfaces
{
    public interface IRecipesService
    {
        List<Recipe> GetAll();
        Recipe GetById(int id);
    }
}
