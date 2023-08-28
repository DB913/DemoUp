using DemoUniversity.Domain.Exceptions;

namespace DemoUniversity.Domain.Extensions;

public static class StringExtensions
{
    public static void ValidateLength(this string input, int minSize = 2, int maxSize = 60)
    {
        if (input.Equals(null))
        {
            throw new NullReferenceException(
                "Передаваемое значение не может быть null");
        }

        if (input.Length < minSize || input.Length > maxSize)
        {
            throw new IncorrectStringLengthException($"Длина должна быть от {minSize} до {maxSize} символов");
        }
    }

    public static void ValidateRange(this int input, int minValue = 16, int maxValue = 150)
    {
        if (input == 0)
        {
            throw new NullReferenceException("Значение не может равным 0");
        }

        if (input < minValue || input > maxValue)
        {
            throw new IncorrectRangeException(
                $"Допустимый диапозон принимаемых значений от {minValue} до {maxValue}");
        }
    }

    public static void ValidateEmptyObject(this object input)
    {
        if (input == null)
        {
            throw new EmptyObjectException(
                "Передаваемый объект не может быть null");
        }
    }
}