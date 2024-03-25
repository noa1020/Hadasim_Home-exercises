using System;
using System.Text.RegularExpressions;
namespace CoronaManagementSystem.Validation;

public class ValidationFunctions
{
    public static bool IsValidIsraeliId(string? id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return false;
        // Israeli ID validation logic here
        return Regex.IsMatch(id, @"^\d{9}$") && IsIsraeliIdValid(id);
    }

    private static bool IsIsraeliIdValid(string id)
    {
        // Additional Israeli ID validation logic here
        int[] idDigits = id.Select(c => int.Parse(c.ToString())).ToArray();
        int sum = 0;
        for (int i = 0; i < idDigits.Length - 1; i++)
        {
            int digit = idDigits[i];
            if (i % 2 == 0)
            {
                digit *= 1;
            }
            else
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit -= 9;
                }
            }
            sum += digit;
        }
        int lastDigit = idDigits[idDigits.Length - 1];
        return (sum + lastDigit) % 10 == 0;
    }

    public static bool IsValidIsraeliLandlinePhone(string? phoneNumber)
    {
        // Israeli landline phone validation logic here
        return string.IsNullOrWhiteSpace(phoneNumber) || Regex.IsMatch(phoneNumber, @"^0\d{0,2}-?\d{7}$");
    }

    public static bool IsValidIsraeliMobilePhone(string? phoneNumber)
    {
        // Israeli mobile phone validation logic here
        return !string.IsNullOrWhiteSpace(phoneNumber) && Regex.IsMatch(phoneNumber, @"^05\d(-|\s)?\d{7}$");
    }

    public static bool IsValidString(string? name)
    {
        // String validation logic here
        return !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
    }

    public static bool IsValidBirthDate(DateTime? birthDate)
    {
        // Birth Date validation logic here
        return birthDate != default && birthDate <= DateTime.Today;
    }
}
