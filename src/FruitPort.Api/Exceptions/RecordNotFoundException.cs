namespace FruitPort.Api.Exceptions;

public class RecordNotFoundException : Exception
{
    public RecordNotFoundException(string message)
        : base(message)
    {
    }
}