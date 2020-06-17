using System;
using System.ComponentModel.DataAnnotations;

namespace MyRecipes.Data
{
    public class Log
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Endpoint { get; set; }

        [Required]
        public string Message { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
