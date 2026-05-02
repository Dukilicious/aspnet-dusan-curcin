using System.ComponentModel.DataAnnotations;

namespace CoreFitness.Presentation.ViewModels;

public class SetPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
    // regex is AI generated
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d]).{8,}$", ErrorMessage = "Password must contain uppercase, lowercase, number, and special character.")]
    public string Password { get; set; } = "";
}