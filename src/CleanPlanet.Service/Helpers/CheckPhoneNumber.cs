using CleanPlanet.Service.Exceptions;
using System.Text.RegularExpressions;

namespace CleanPlanet.Service.Helpers;

public static class CheckPhoneNumber
{
    public static bool IsValid(string phone)
    {
        string pattern = @"^\+998(90|91|93|94|97|88|20|33|70|99|77)[0-9]{7}$";
        if (!Regex.IsMatch(phone, pattern))
            throw new CustomException(403, "Invalid phone number");
        return true;
    }
}