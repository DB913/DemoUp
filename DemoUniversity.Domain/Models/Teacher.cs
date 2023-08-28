using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models;

public class Teacher : Person
{
    /// <summary>
    /// Конструктор для валидации и присваивания значений полям учителя
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="age">Возраст</param>
    /// <param name="fio"></param>
    /// <param name="address">Адрес</param>
    /// <param name="phone">Номер телефона</param>
    public Teacher(Guid id, Fio fio, Address address, string phone, int age) 
        : base(id, fio, address, phone, age)
    {
        
    }
}