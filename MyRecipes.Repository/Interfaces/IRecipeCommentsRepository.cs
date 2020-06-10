using MyRecipes.Data;

namespace MyRecipes.Repository.Interfaces
{
    public interface IRecipeCommentsRepository
    {
        void Add(RecipeComment comment);
    }
}
