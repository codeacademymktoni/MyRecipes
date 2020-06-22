using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipes.Services.Interfaces
{
    public interface IRecipeLikesService
    {
        void AddLike(int recipeId, int userId);
        void RemoveLike(int recipeId, int userId);
    }
}
