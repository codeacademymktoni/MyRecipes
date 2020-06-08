using System;

namespace MyRecipes.ViewModels
{
    public class RecipeCommentModel
    {
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public string Username { get; set; }
    }
}
