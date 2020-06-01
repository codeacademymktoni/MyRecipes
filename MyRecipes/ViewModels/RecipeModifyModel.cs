using System;
using System.ComponentModel.DataAnnotations;

namespace MyRecipes.ViewModels
{
    public class RecipeModifyModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string Directions { get; set; }
        public DateTime? DateCreated { get; set; }
        public int Views { get; set; }
    }
}
