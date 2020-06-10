using MyRecipes.Data;
using MyRecipes.Repository.Interfaces;

namespace MyRecipes.Repository
{
    public class RecipeCommentsRepository : IRecipeCommentsRepository
    {
        private MyRecipesContext Context { get; set; }

        public RecipeCommentsRepository(MyRecipesContext context)
        {
            Context = context;
        }

        public void Add(RecipeComment comment)
        {
            Context.RecipeComments.Add(comment);
            Context.SaveChanges();
        }
    }
}
