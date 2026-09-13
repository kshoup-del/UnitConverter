using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitOf;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)] public string Input { get; set; } = string.Empty;

    [BindProperty(SupportsGet = true)] public string ConversionType { get; set; } = string.Empty;

    public string Output { get; set; } = string.Empty;

    public void OnGet()
    {

        if (string.IsNullOrWhiteSpace(ConversionType) &&
            string.IsNullOrWhiteSpace(Input))
        {
            ConversionType = "MilesToKilometers";
            Input = "3.1415";
            ViewData["ConversionType"] = "Miles to Kilometers";
        }
        else
        {

            ViewData["ConversionType"] = ConversionType;
        }

        double value;

        try
        {
            value = Convert.ToDouble(Input);
        }
        catch (Exception)
        {
            ViewData["ErrorMessage"] = "Input must be a valid number";
            return;
        }

        double result;
        try
        {
            switch (ConversionType)
            {
                case "MilesToKilometers":
                    result = new UnitOf.Length().FromMiles(value).ToKilometers();
                    break;

                case "KilometersToMiles":
                    result = new UnitOf.Length().FromKilometers(value).ToMiles();
                    break;

                case "FahrenheitToCelsius":
                    result = new UnitOf.Temperature().FromFahrenheit(value).ToCelsius();
                    break;
                case "CelsiusToFahrenheit":
                    result = new UnitOf.Temperature().FromCelsius(value).ToFahrenheit();
                    break;

                case "PoundsToKilograms":
                    result = new UnitOf.Mass().FromPounds(value).ToKilograms();
                    break;
                case "KilogramsToPounds":
                    result = new UnitOf.Mass().FromKilograms(value).ToPounds();
                    break;
                case "FeetToMeters":
                    result = new UnitOf.Length().FromFeet(value).ToMeters();
                    break;
                case "MetersToFeet":
                    result = new UnitOf.Length().FromMeters(value).ToFeet();
                    break;

                default:
                    ViewData["ErrorMessage"] = "Invalid conversion type";
                    return;
            }
        }
        catch (Exception e)
        {
            ViewData["ErrorMessage"] = "Could not convert " + ConversionType;
            return;
        }

        Output = result.ToString();
        ViewData["Title"] = "Conversions";
    }
}
