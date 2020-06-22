using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRecipes.Data
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        public virtual List<RecipeComment> RecipeComments { get; set; }
        public virtual List<Log> Logs { get; set; }
        public virtual List<RecipeLike> RecipeLikes { get; set; }
    }
}
