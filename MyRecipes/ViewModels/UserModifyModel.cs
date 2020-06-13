using System.ComponentModel.DataAnnotations;

namespace MyRecipes.ViewModels
{
    public class UserModifyModel
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
    }
}
