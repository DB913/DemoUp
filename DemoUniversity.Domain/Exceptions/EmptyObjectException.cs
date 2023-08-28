namespace DemoUniversity.Domain.Exceptions;

public class EmptyObjectException : Exception
{
    public EmptyObjectException(string message) : base(message)
    {
        
    }
}