using UnitConverter.Models;

namespace UnitConverter.Services;

public class UnitOfConversionService : IConversionService
{
    public decimal Convert(decimal value, string conversionType)
    {
        decimal result;

        switch (conversionType)
        {
            case ConversionTypes.MilesToKilometers:
                result = (decimal)new UnitOf.Length().FromMiles((double)value).ToKilometers();
                break;

            case ConversionTypes.KilometersToMiles:
                result = (decimal)new UnitOf.Length().FromKilometers((double)value).ToMiles();
                break;

            case ConversionTypes.FahrenheitToCelsius:
                result = (decimal)new UnitOf.Temperature().FromFahrenheit((double)value).ToCelsius();
                break;
            case ConversionTypes.CelsiusToFahrenheit:
                result = (decimal)(new UnitOf.Temperature().FromCelsius((double)value).ToFahrenheit());
                break;

            case ConversionTypes.PoundsToKilograms:
                result = (decimal)new UnitOf.Mass().FromPounds((double)value).ToKilograms();
                break;
            case ConversionTypes.KilogramsToPounds:
                result = (decimal)new UnitOf.Mass().FromKilograms((double)value).ToPounds();
                break;
            case ConversionTypes.FeetToMeters:
                result = (decimal)new UnitOf.Length().FromFeet((double)value).ToMeters();
                break;
            case ConversionTypes.MetersToFeet:
                result = (decimal)new UnitOf.Length().FromMeters((double)value).ToFeet();
                break;

            default:
                throw new ArgumentException("Unknown conversion type", nameof(conversionType));
        }

        return result;
    }
}
