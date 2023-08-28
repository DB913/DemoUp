namespace DemoUniversity.Domain.Exceptions;

public class IncorrectStringLengthException : Exception
{
    public IncorrectStringLengthException(string message)
        : base(message)
    {
    }
}