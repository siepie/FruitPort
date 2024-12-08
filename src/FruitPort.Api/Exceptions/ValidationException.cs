namespace FruitPort.Api.Exceptions;

public class ValidationException : Exception
{
    public string PropertyName { get; }

    public ValidationException(string message, string propertyName)
        : base(message)
    {
        PropertyName = propertyName;
    }
}