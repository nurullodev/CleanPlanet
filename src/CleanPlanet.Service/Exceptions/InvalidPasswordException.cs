namespace CleanPlanet.Service.Exceptions;

public class InvalidPasswordException : Exception
{
    public InvalidPasswordException(string message) : base(message)
    { }

    public InvalidPasswordException(string message, Exception innerException) : base(message, innerException)
    { }

    public int StatusCode { get; set; } = 401;
}