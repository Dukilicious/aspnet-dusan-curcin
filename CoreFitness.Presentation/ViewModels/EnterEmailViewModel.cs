using System.ComponentModel.DataAnnotations;

namespace CoreFitness.Presentation.ViewModels;

public class EnterEmailViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";
}