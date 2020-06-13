using System.ComponentModel.DataAnnotations;

namespace MyRecipes.ViewModels
{
    public class UserChangePassModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "The password must contain at least one captial letter and one digit")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat Password")]
        public string RepeatPassword { get; set; }
    }
}
