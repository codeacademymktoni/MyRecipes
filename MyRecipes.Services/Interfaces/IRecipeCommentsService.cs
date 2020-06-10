namespace MyRecipes.Services.Interfaces
{
    public interface IRecipeCommentsService
    {
        void Add(string comment, int recipeId, int userId);
    }
}
