using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyRecipes.Data
{
    public class RecipeComment
    {
        public int Id { get; set; }

        [Required]
        public string Comment { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
