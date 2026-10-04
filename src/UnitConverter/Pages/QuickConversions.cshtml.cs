using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitConverter.Models;
using UnitConverter.Services;

namespace UnitConverter.Pages;

public class QuickConversions : PageModel
{
    private readonly IConversionService _conversionService;

    public QuickConversions(IConversionService conversionService)
    {
        _conversionService = conversionService;
    }

    public decimal? Output { get; set; }

    public string? ErrorMessage { get; set; }
    public void OnGet()
    {

    }

    public IActionResult OnGetMilesToKilometers(string input)
    {
       return Convert(ConversionTypes.MilesToKilometers,input);
    }

    public IActionResult OnGetKilometersToMiles(string input)
    {
        return Convert(ConversionTypes.KilometersToMiles,input);
    }

    public IActionResult OnGetCelsiusToFahrenheit(string input)
    {
        return Convert(ConversionTypes.CelsiusToFahrenheit,input);
    }
    public IActionResult OnGetFahrenheitToCelsius(string input)
    {
        return Convert(ConversionTypes.FahrenheitToCelsius,input);
    }

    public IActionResult OnGetPoundsToKilograms(string input)
    {
        return Convert(ConversionTypes.PoundsToKilograms,input);
    }
    public IActionResult OnGetKilogramsToPounds(string input)
    {
        return Convert(ConversionTypes.KilogramsToPounds,input);
    }

    public IActionResult OnGetFeetToMeters(string input)
    {
        return Convert(ConversionTypes.FeetToMeters,input);
    }

    public IActionResult OnGetMetersToFeet(string input)
    {
        return Convert(ConversionTypes.MetersToFeet,input);
    }

    public List<SelectListItem> PoundOptions { get; } =
    [
        new SelectListItem("1","1"),
        new SelectListItem("5","5"),
        new SelectListItem("10","10"),
        new SelectListItem("25","25"),
        new SelectListItem("50","50")

    ];

    private IActionResult Convert(string conversionType, string input)
    {
        if (!decimal.TryParse(input, out decimal value))
        {
            ErrorMessage = "Please enter a valid number";
            return Page();

        }

        try
        {
            Output = _conversionService.Convert(value, conversionType);
        }
        catch (ArgumentException)
        {
            ErrorMessage = "The selected conversion type is not valid";
            return Page();
        }

        return Page();
    }

}
