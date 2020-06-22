using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyRecipes.Data
{
    public class RecipeLike
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual Recipe Recipe { get; set; }
        [Required]
        public int RecipeId { get; set; }

        public virtual User User { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
