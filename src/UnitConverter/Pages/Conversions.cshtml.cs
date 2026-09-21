using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverter.Models;

namespace UnitConverter.Pages
{
    public class ConversionsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ConversionType { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string Input { get; set; } = string.Empty;

        public string Output { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public ConversionModel Conversion { get; set; } = new();

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(ConversionType) &&
                !string.IsNullOrWhiteSpace(Conversion.ConversionType))
            {
                ConversionType = Conversion.ConversionType;
            }

            if (string.IsNullOrWhiteSpace(Input) &&
                !string.IsNullOrWhiteSpace(Conversion.Input))
            {
                Input = Conversion.Input;
            }
            if (string.IsNullOrWhiteSpace(ConversionType) &&
                string.IsNullOrWhiteSpace(Input))
            {
                ConversionType = ConversionTypes.MilesToKilometers;
                Input = "3.1415";
            }

            Conversion.ConversionType = ConversionType;
            Conversion.Input = Input;

            if (!ConversionTypes.All.TryGetValue(Conversion.ConversionType, out var displayName))
            {
                ViewData["ErrorMessage"] = "Unknown conversion type.";
                ViewData["Title"] = "Conversions";
                return;
            }

            ViewData["ConversionType"] = displayName;
            ViewData["Title"] = "Conversions";

            if (!double.TryParse(Conversion.Input, out var value))
            {
                ViewData["ErrorMessage"] = "Input must be a valid number.";
                return;
            }

            double result;
            try
            {
                switch (ConversionType.Trim())
                {
                    case ConversionTypes.MilesToKilometers:
                        result = new UnitOf.Length().FromMiles(value).ToKilometers();
                        break;

                    case ConversionTypes.KilometersToMiles:
                        result = new UnitOf.Length().FromKilometers(value).ToMiles();
                        break;

                    case ConversionTypes.FahrenheitToCelsius:
                        result = new UnitOf.Temperature().FromFahrenheit(value).ToCelsius();
                        break;
                    case ConversionTypes.CelsiusToFahrenheit:
                        result = new UnitOf.Temperature().FromCelsius(value).ToFahrenheit();
                        break;

                    case ConversionTypes.PoundsToKilograms:
                        result = new UnitOf.Mass().FromPounds(value).ToKilograms();
                        break;
                    case ConversionTypes.KilogramsToPounds:
                        result = new UnitOf.Mass().FromKilograms(value).ToPounds();
                        break;
                    case ConversionTypes.FeetToMeters:
                        result = new UnitOf.Length().FromFeet(value).ToMeters();
                        break;
                    case ConversionTypes.MetersToFeet:
                        result = new UnitOf.Length().FromMeters(value).ToFeet();
                        break;

                    default:
                        ViewData["ErrorMessage"] = "Unknown conversion type.";
                        return;
                }
            }
            catch (Exception)
            {
                ViewData["ErrorMessage"] = $"Could not convert using {Conversion.ConversionType}.";
                return;
            }

            Output = result.ToString();
            Conversion.Output = Output;

        }
    }
}
