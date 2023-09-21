using System.Text.RegularExpressions;

namespace Utilities.Validations;
public class CarValidation
    {
    public static string? ValidateCarName(string? carName)
    {
        if (carName == null) return null;

        if (!Regex.IsMatch(carName, "^.{2,50}$"))
        {
            return "Car name must be between 2 and 50 characters and contain only letters and numbers.";
        }
        return null;
    }

    public static string? ValidateCarDescription(string? carDescription)
    {
        if (carDescription == null) return null;

        if (!Regex.IsMatch(carDescription, "^.{2,220}$"))
        {
            return "Car description must be between 9 and 12 characters.";
        }
        return null;
    }

    public static string? ValidateNumberOfDoors(int? numberOfDoors)
    {
        if (numberOfDoors == null) return null;

        if (numberOfDoors < 1 || numberOfDoors > 10)
        {
            return "Number of doors must be in between 1 and 10.";
        }
        return null;
    }

    public static string? ValidateSeatCapacity(int? seatCapacity)
    {
        if (seatCapacity == null) return null;

        if (seatCapacity < 1 || seatCapacity > 100)
        {
            return "Seat capacity must be in between 1 and 100.";
        }
        return null;
    }

    public static string? ValidateFuelType(string? fuelType)
    {
        if (fuelType == null) return null;

        if (!Regex.IsMatch(fuelType, "^.{2,20}$"))
        {
            return "Fuel type must be between 2 and 20 characters.";
        }
        return null;
    }

    public static string? ValidateYear(int? year)
    {
        if (year == null) return null;

        if (year > DateTime.Now.Year)
        {
            return "Year must not be exceed than the current year.";
        }
        return null;
    }

    public static string? ValidateCarRentingPricePerDay(decimal? price)
    {
        if (price == null) return null;

        if (price <= 0)
        {
            return "Price must be higher than 0.";
        }
        return null;
    }

}

public class CarErrors
{
    public string? CarNameError { get; set; }
    public string? CarDescriptionError { get; set; }
    public string? NumberOfDoorsError { get; set; }
    public string? SeatingCapacityError { get; set; }
    public string? FuelTypeError { get; set; }
    public string? YearError { get; set; }
    public string? CarRentingPricePerDayError { get; set; }

    public bool NoError()
    {
        return CarNameError == null &&
            CarDescriptionError == null &&
            NumberOfDoorsError == null &&
            SeatingCapacityError == null &&
            FuelTypeError == null &&
            YearError == null &&
            CarRentingPricePerDayError == null;
    }
}


