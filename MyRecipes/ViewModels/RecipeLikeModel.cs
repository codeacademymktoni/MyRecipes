using System;

namespace MyRecipes.ViewModels
{
    public class RecipeLikeModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
