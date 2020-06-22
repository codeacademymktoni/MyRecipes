using MyRecipes.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipes.Repository.Interfaces
{
    public interface IRecipeLikesRepository
    {
        void Add(RecipeLike like);
        RecipeLike Get(int recipeId, int userId);
        void Remove(RecipeLike like);
        void Update(RecipeLike currentLike);
    }
}
