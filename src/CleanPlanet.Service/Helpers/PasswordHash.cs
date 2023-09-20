namespace CleanPlanet.Service.Helpers;

public static class PasswordHash
{
    public static string Encrypt(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public static bool Verify(string hashedPassword, string password)
        => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}