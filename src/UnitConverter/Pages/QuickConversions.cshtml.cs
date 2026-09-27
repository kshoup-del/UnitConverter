using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitConverter.Models;
using UnitConverter.Models;

namespace UnitConverter.Pages;

public class QuickConversions : PageModel
{
    public void OnGet()
    {

    }

    public IActionResult OnGetMilesToKilometers(string input)
    {
       return RedirectToConversion(ConversionTypes.MilesToKilometers,input);
    }

    public IActionResult OnGetKilometersToMiles(string input)
    {
        return RedirectToConversion(ConversionTypes.KilometersToMiles,input);
    }

    public IActionResult OnGetCelsiusToFahrenheit(string input)
    {
        return RedirectToConversion(ConversionTypes.CelsiusToFahrenheit,input);
    }
    public IActionResult OnGetFahrenheitToCelsius(string input)
    {
        return RedirectToConversion(ConversionTypes.FahrenheitToCelsius,input);
    }

    public IActionResult OnGetPoundsToKilograms(string input)
    {
        return RedirectToConversion(ConversionTypes.PoundsToKilograms,input);
    }
    public IActionResult OnGetKilogramsToPounds(string input)
    {
        return RedirectToConversion(ConversionTypes.KilogramsToPounds,input);
    }

    public IActionResult OnGetFeetToMeters(string input)
    {
        return RedirectToConversion(ConversionTypes.FeetToMeters,input);
    }

    public IActionResult OnGetMetersToFeet(string input)
    {
        return RedirectToConversion(ConversionTypes.MetersToFeet,input);
    }

    public List<SelectListItem> PoundOptions { get; } =
    [
        new SelectListItem("1","1"),
        new SelectListItem("5","5"),
        new SelectListItem("10","10"),
        new SelectListItem("25","25"),
        new SelectListItem("50","50")

    ];

    private IActionResult RedirectToConversion(string conversionType, string input)
    {
        return RedirectToPage(
            "/Conversions",
            new
            {
                ConversionType = conversionType,
                Input = input
            });
    }

}
