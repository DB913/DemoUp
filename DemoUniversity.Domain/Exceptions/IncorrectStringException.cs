namespace DemoUniversity.Domain.Exceptions;

public class IncorrectStringException : Exception
{
    public IncorrectStringException(string message)
        : base(message)
    {
    }
}