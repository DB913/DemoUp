using DemoUniversity.Domain.Exceptions;

namespace DemoUniversity.Domain.Models;

public abstract class BaseData<TId> where TId : struct
{
    public TId Id { get; set; }

    protected BaseData(TId id)
    {
        ValidateId(id);
        Id = id;
    }

    private static void ValidateId(TId id)
    {
        if (EqualityComparer<TId>.Default.Equals(id, default))
        {
            throw new IncorrectIdException("Некорректное значение id");
        }
    }
}