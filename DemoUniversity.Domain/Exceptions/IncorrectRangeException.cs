﻿namespace DemoUniversity.Domain.Exceptions;

public class IncorrectRangeException : Exception
{
    public IncorrectRangeException(string message) : base(message)
    {
    }
}