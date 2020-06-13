using System.ComponentModel.DataAnnotations;

namespace MyRecipes.ViewModels
{
    public class CreateUserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "The password must contain at least one captial letter and one digit")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }

        public bool IsAdmin { get; set; }
    }
}
