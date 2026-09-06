using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitOf;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    public string Input { get; set; } = string.Empty;
    public string Output { get; set; } = string.Empty;
    public void OnGet()
    {
        Input = "3.1415";

        ViewData["ConversionType"] = "Miles to Kilometers";

        ViewData["Title"] = "Conversions";

        double miles = Convert.ToDouble(Input);

        UnitOf.Length unit = new UnitOf.Length().FromMiles(miles);
        double kilometers = unit.ToKilometers();

        Output = kilometers.ToString();


    }
}
