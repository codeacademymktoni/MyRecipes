using System.ComponentModel.DataAnnotations;

namespace MyRecipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Directions { get; set; }
    }
}
