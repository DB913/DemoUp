using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models;

public class Student : Person
{
    /// <summary>
    /// Специальность студента
    /// </summary>
    public string Speciality { get; private set; }

    /// <summary>
    /// Курс студента
    /// </summary>
    public int Course { get; private set; }

    /// <summary>
    /// Конструктор для валидации и присваивания значений полям студента
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="age">Возраст</param>
    /// <param name="speciality">Специальность</param>
    /// <param name="course">Курс</param>
    /// <param name="fio">ФИО</param>
    /// <param name="address">Адрес</param>
    /// <param name="phone">Номер телефона</param>
    public Student(Guid id, Fio fio, Address address, string phone,
        int age,
        string speciality, int course) : base(id,fio, address, phone, age)
    {
        speciality.ValidateLength(2, 10);
        course.ValidateRange(1, 6);
        Speciality = speciality;
        Course = course;
    }

    /// <summary>
    /// Метод для обновления специальности студента
    /// </summary>
    /// <param name="speciality">Новая специальность</param>
    public void UpdateStudentSpeciality(string speciality)
    {
        speciality.ValidateLength(2, 10);
        Speciality = speciality;
    }

    /// <summary>
    /// Метод для обновления курса студента
    /// </summary>
    /// <param name="course">Обновленный курс</param>
    public void UpdateStudentCourse(int course)
    {
        course.ValidateRange(1, 6);
        Course = course;
    }
}