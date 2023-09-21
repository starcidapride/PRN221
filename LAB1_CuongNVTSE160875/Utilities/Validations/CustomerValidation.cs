using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities.Validations;
    public class CustomerValidation
    {
    public static string? ValidateCustomerName(string? customerName)
    {
        if (customerName == null) return null;

        if (!Regex.IsMatch(customerName, "^[A-Za-z0-9 ]{2,50}$"))
        {
            return "Customer name must be between 2 and 50 characters and contain only letters and numbers.";
        }
        return null;
    }

    public static string? ValidateTelephone(string? telephone)
    {
        if (telephone == null) return null;

        if (!Regex.IsMatch(telephone, "^\\d{9,12}$"))
        {
            return "Telephone number must be between 9 and 12 digits.";
        }
        return null;
    }

    public static string? ValidateEmail(string? email)
    {
        if (email == null) return null;

        if (!Regex.IsMatch(email, "^(?=.{1,50}$)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$"))
        {
            return "Invalid email format. Email must be valid and have a maximum length of 50 characters.";
        }
        return null;
    }

    public static string? ValidateCustomerBirthday(DateTime? customerBirthday)
    {
        if (customerBirthday == null) return null;

        if (customerBirthday > DateTime.Now)
        {
            return "Customer birthday cannot be in the future.";
        }
        return null;
    }

    public static string? ValidatePassword(string? password)
    {
        if (password == null) return null;

        if (Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\W)(?=.*\d).{6,20}$"))
        {
            return "Customer birthday cannot be in the future.";
        }
        return null;
    }
}

public class CustomerErrors
{

    public string? CustomerNameError { get; set; }
    public string? TelephoneError { get; set; }
    public string? EmailError { get; set; }
    public string? CustomerBirthdayError { get; set; }
    public string? PasswordError { get; set; }

    public bool NoError()
    {
        return CustomerNameError == null &&
            TelephoneError == null &&
            EmailError == null &&
            EmailError == null &&
            CustomerBirthdayError == null
            ;
    }
}