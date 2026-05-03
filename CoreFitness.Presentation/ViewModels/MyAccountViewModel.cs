namespace CoreFitness.Presentation.ViewModels;

public class MyAccountViewModel
{
    public string ActiveTab { get; set; } = "about";
    public AboutMeViewModel AboutMe { get; set; } = new();
}