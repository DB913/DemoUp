using Bogus;
using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Models;
using Person = DemoUniversity.Domain.Models.Person;

namespace DemoUniversityTests.Unit;

public class StudentTest
{
    [Fact]
    public void SetCreateStudentPositiveTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        Assert.True(student.Id == studentId);

        Assert.True(student.PersonAddress.City == cityStudent);
        Assert.True(student.PersonAddress.Street == streetStudent);
        Assert.True(student.PersonAddress.HouseNumber == houseNumber);
        Assert.True(student.PersonAddress.ApartmentNumber == apartmentNumber);

        Assert.True(student.PersonFio.LastName == lastName);
        Assert.True(student.PersonFio.FirstName == firstName);
        Assert.True(student.PersonFio.MiddleName == middleName);

        Assert.True(student.Phone == phone);
        Assert.True(student.Age == age);
        Assert.True(student.Speciality == speciality);
        Assert.True(student.Course == course);
    }

    [Theory]
    [InlineData("c")]
    [InlineData(
        "CheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTest")]
    [InlineData("")]
    public void CheckExceptionForInvalidCityTest(string cityStudent)
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Fact]
    public void CheckExceptionForNullCityTest()
    {
        var faker = new Faker("ru");

        string cityStudent = null;
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Theory]
    [InlineData("c")]
    [InlineData(
        "CheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTest")]
    [InlineData("")]
    public void CheckExceptionForInvalidStreetTest(string streetStudent)
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Fact]
    public void CheckExceptionForNullStreetTest()
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        string streetStudent = null;
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(401)]
    [InlineData(6546464)]
    [InlineData(-6546464)]
    public void CheckExceptionForInvalidHouseNumberTest(int houseNumber)
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int apartmentNumber = 5;

        IncorrectRangeException ex = Assert.Throws<IncorrectRangeException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(1000)]
    [InlineData(56464464)]
    [InlineData(-56464464)]
    public void CheckExceptionForInvalidApartmentNumberTest(int apartmentNumber)
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 256;

        IncorrectRangeException ex = Assert.Throws<IncorrectRangeException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Fact]
    public void CheckExceptionForZeroHouseNumberTest()
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 0;
        const int apartmentNumber = 5;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Fact]
    public void CheckExceptionForZeroApartmentNumberTest()
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 256;
        const int apartmentNumber = 0;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Theory]
    [InlineData("d")]
    [InlineData("d12345678910TestRest")]
    [InlineData("")]
    public void CheckExceptionForInvalidSpecialityTest(string speciality)
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const int course = 4;

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(7)]
    [InlineData(56464464)]
    public void CheckExceptionForInvalidCourseTest(int course)
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";

        IncorrectRangeException ex = Assert.Throws<IncorrectRangeException>(() =>
            new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }


    [Fact]
    public void CheckExceptionForZeroCourseTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 0;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }

    [Fact]
    public void CheckExceptionForNullSpecialityTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = null;
        const int course = 4;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }

    [Theory]
    [InlineData("d")]
    [InlineData(
        "d12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRest")]
    [InlineData("")]
    public void CheckExceptionForInvalidLastNameTest(string lastName)
    {
        var faker = new Faker("ru");

        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Person.Fio(lastName, firstName, middleName));
    }

    [Theory]
    [InlineData("d")]
    [InlineData(
        "d12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRest")]
    [InlineData("")]
    public void CheckExceptionForInvalidFirstNameTest(string firstName)
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var middleName = faker.Name.FirstName();

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Person.Fio(lastName, firstName, middleName));
    }

    [Theory]
    [InlineData("d")]
    [InlineData(
        "d12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRest")]
    [InlineData("")]
    public void CheckExceptionForInvalidMiddleNameTest(string middleName)
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Person.Fio(lastName, firstName, middleName));
    }

    [Fact]
    public void CheckExceptionForNullLastNameStudentTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        string lastName = null;
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        NullReferenceException ex =
            Assert.Throws<NullReferenceException>(() => new Person.Fio(lastName, firstName, middleName));
    }

    [Fact]
    public void CheckExceptionForNullFirstNameStudentTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.FirstName();
        ;
        string firstName = null;
        var middleName = faker.Name.FirstName();

        NullReferenceException ex =
            Assert.Throws<NullReferenceException>(() => new Person.Fio(lastName, firstName, middleName));
    }

    [Fact]
    public void CheckExceptionForNullMiddleNameStudentTest()
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.FirstName();

        var firstName = faker.Name.FirstName();
        string middleName = null;

        NullReferenceException ex =
            Assert.Throws<NullReferenceException>(() => new Person.Fio(lastName, firstName, middleName));
    }

    [Theory]
    [InlineData(15)]
    [InlineData(151)]
    [InlineData(-5564)]
    public void CheckExceptionForInvalidAgeStudentTest(int age)
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const string speciality = "doctor";
        const int course = 4;

        IncorrectRangeException ex =
            Assert.Throws<IncorrectRangeException>(() =>
                new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }

    [Fact]
    public void CheckExceptionForZeroAgeStudentTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const string speciality = "doctor";
        const int course = 4;
        int age = 0;

        NullReferenceException ex =
            Assert.Throws<NullReferenceException>(() =>
                new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }

    [Theory]
    [InlineData("")]
    [InlineData("151")]
    [InlineData("534534534")]
    [InlineData("37377941456")]
    [InlineData("77941456")]
    [InlineData("077941456")]
    public void CheckExceptionForInvalidPhoneNumberStudentTest(string phone)
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string speciality = "doctor";
        const int course = 4;
        const int age = 25;

        IncorrectStringException ex =
            Assert.Throws<IncorrectStringException>(() =>
                new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }

    [Fact]
    public void CheckExceptionForNullPhoneNumberStudentTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string speciality = "doctor";
        const int course = 4;
        const int age = 25;
        const string phoneNumber = null;

        NullReferenceException ex =
            Assert.Throws<NullReferenceException>(() =>
                new Student(studentId, fioStudent, studentAddress, phoneNumber, age, speciality, course));
    }

    [Fact]
    public void UpdateStudentAddressPositiveTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        var cityStudentUp = faker.Address.City() + "Up";
        var streetStudentUp = faker.Address.StreetName() + "Up";
        const int houseNumberUp = 45 + houseNumber;
        const int apartmentNumberUp = 5 + apartmentNumber;

        studentAddress.UpdateAddress(cityStudentUp, streetStudentUp, houseNumberUp, apartmentNumberUp);

        Assert.True(student.PersonAddress.City == cityStudentUp);
        Assert.True(student.PersonAddress.Street == streetStudentUp);
        Assert.True(student.PersonAddress.HouseNumber == houseNumberUp);
        Assert.True(student.PersonAddress.ApartmentNumber == apartmentNumberUp);
    }

    [Fact]
    public void CheckExceptionForUpdateStudentAddressTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        EmptyObjectException ex = Assert.Throws<EmptyObjectException>(() =>
            student.UpdateStudentAddress(null));
    }

    [Fact]
    public void UpdateAddressPropertyPositiveTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        var cityStudentUp = faker.Address.City() + "Up";
        var streetStudentUp = faker.Address.StreetName() + "Up";
        const int houseNumberUp = 45 + houseNumber;
        const int apartmentNumberUp = 5 + apartmentNumber;

        var studentAddressUpdate = new Person.Address(cityStudentUp, streetStudentUp, houseNumberUp, apartmentNumberUp);

        student.UpdateStudentAddress(studentAddressUpdate);

        Assert.True(student.PersonAddress.City == cityStudentUp);
        Assert.True(student.PersonAddress.Street == streetStudentUp);
        Assert.True(student.PersonAddress.HouseNumber == houseNumberUp);
        Assert.True(student.PersonAddress.ApartmentNumber == apartmentNumberUp);
    }

    [Theory]
    [InlineData("c")]
    [InlineData(
        "CheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTest")]
    [InlineData("")]
    public void CheckExceptionForInvalidUpdateCityTest(string cityStudentUp)
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var streetStudentUp = faker.Address.StreetName() + "Up";
        const int houseNumberUp = 45 + houseNumber;
        const int apartmentNumberUp = 5 + apartmentNumber;

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            studentAddress.UpdateAddress(cityStudentUp, streetStudentUp, houseNumberUp, apartmentNumberUp));
    }

    [Fact]
    public void CheckExceptionForNullUpdateCityTest()
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        string cityStudentUp = null;
        var streetStudentUp = faker.Address.StreetName() + "Up";
        const int houseNumberUp = 45 + houseNumber;
        const int apartmentNumberUp = 5 + apartmentNumber;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            studentAddress.UpdateAddress(cityStudentUp, streetStudentUp, houseNumberUp, apartmentNumberUp));
    }

    [Theory]
    [InlineData("c")]
    [InlineData(
        "CheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTest")]
    [InlineData("")]
    public void CheckExceptionForInvalidUpdateStreetTest(string streetStudentUp)
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var cityStudentUp = faker.Address.City() + "Up";
        const int houseNumberUp = 45 + houseNumber;
        const int apartmentNumberUp = 5 + apartmentNumber;

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            studentAddress.UpdateAddress(cityStudentUp, streetStudentUp, houseNumberUp, apartmentNumberUp));
    }

    [Fact]
    public void CheckExceptionForNullUpdateStreetTest()
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var cityStudentUp = faker.Address.City() + "Up";
        string streetStudentUp = null;
        const int houseNumberUp = 45 + houseNumber;
        const int apartmentNumberUp = 5 + apartmentNumber;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            studentAddress.UpdateAddress(cityStudentUp, streetStudentUp, houseNumberUp, apartmentNumberUp));
    }

    [Theory]
    [InlineData(-565)]
    [InlineData(401)]
    public void CheckExceptionForInvalidUpdateHouseNumberTest(int houseNumberUp)
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int apartmentNumber = 5;
        const int houseNumber = 56;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var cityStudentUp = faker.Address.City() + "Up";
        var streetStudentUp = faker.Address.StreetName() + "Up";
        const int apartmentNumberUp = 5 + apartmentNumber;

        IncorrectRangeException ex = Assert.Throws<IncorrectRangeException>(() =>
            studentAddress.UpdateAddress(cityStudentUp, streetStudentUp, houseNumberUp, apartmentNumberUp));
    }

    [Fact]
    public void CheckExceptionForZeroUpdateHouseNumberTest()
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var cityStudentUp = faker.Address.City() + "Up";
        var streetStudentUp = faker.Address.StreetName() + "Up";
        const int houseNumberUp = 0;
        const int apartmentNumberUp = 5 + apartmentNumber;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            studentAddress.UpdateAddress(cityStudentUp, streetStudentUp, houseNumberUp, apartmentNumberUp));
    }

    [Theory]
    [InlineData(-565)]
    [InlineData(1000)]
    public void CheckExceptionForInvalidUpdateApartmentNumberTest(int apartmentNumberUp)
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int apartmentNumber = 5;
        const int houseNumber = 56;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var cityStudentUp = faker.Address.City() + "Up";
        var streetStudentUp = faker.Address.StreetName() + "Up";
        var houseNumberUp = 56;

        IncorrectRangeException ex = Assert.Throws<IncorrectRangeException>(() =>
            studentAddress.UpdateAddress(cityStudentUp, streetStudentUp, houseNumberUp, apartmentNumberUp));
    }

    [Fact]
    public void CheckExceptionForZeroUpdateApartmentNumberTest()
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var cityStudentUp = faker.Address.City() + "Up";
        var streetStudentUp = faker.Address.StreetName() + "Up";
        const int houseNumberUp = 46;
        const int apartmentNumberUp = 0;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            studentAddress.UpdateAddress(cityStudentUp, streetStudentUp, houseNumberUp, apartmentNumberUp));
    }

    [Fact]
    public void UpdateStudentFioPositiveTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        var lastNameUp = faker.Name.LastName() + "Up";
        var firstNameUp = faker.Name.FirstName() + "Up";
        var middleNameUp = faker.Name.FirstName() + "Up";

        fioStudent.UpdateFio(lastNameUp, firstNameUp, middleNameUp);

        Assert.True(student.PersonFio.LastName == lastNameUp);
        Assert.True(student.PersonFio.FirstName == firstNameUp);
        Assert.True(student.PersonFio.MiddleName == middleNameUp);
    }

    [Fact]
    public void UpdateStudentFioPropertyPositiveTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        var lastNameUp = faker.Name.LastName() + "Up";
        var firstNameUp = faker.Name.FirstName() + "Up";
        var middleNameUp = faker.Name.FirstName() + "Up";

        var fioStudentUp = new Person.Fio(lastNameUp, firstNameUp, middleNameUp);

        student.UpdateStudentFio(fioStudentUp);

        Assert.True(student.PersonFio.LastName == lastNameUp);
        Assert.True(student.PersonFio.FirstName == firstNameUp);
        Assert.True(student.PersonFio.MiddleName == middleNameUp);
    }

    [Fact]
    public void CheckExceptionForUpdateStudentFioPropertyTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        EmptyObjectException ex = Assert.Throws<EmptyObjectException>(() =>
            student.UpdateStudentFio(null));
    }

    [Fact]
    public void UpdateStudentAgePositiveTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        const int ageUp = 25 + age;
        student.UpdateAge(ageUp);

        Assert.True(student.Age == ageUp);
    }

    [Fact]
    public void UpdatePhoneNumberStudentPositiveTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        const string phoneUp = "+37377941777";
        student.UpdatePhoneNumber(phoneUp);

        Assert.True(student.Phone == phoneUp);
    }

    [Fact]
    public void CheckExceptionForNullAddressTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        EmptyObjectException ex = Assert.Throws<EmptyObjectException>(() =>
            new Student(studentId, fioStudent, null, phone, age, speciality, course));
    }

    [Theory]
    [InlineData("")]
    [InlineData(
        "specialityUpspecialityUpspecialityUpspecialityUpspecialityUpspecialityUpspecialityUpspecialityUpspecialityUpspecialityUpspecialityUp")]
    [InlineData("u")]
    public void CheckExceptionForUpdateInvalidSpecialityTest(string specialityUp)
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "testRest";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            student.UpdateStudentSpeciality(specialityUp));
    }

    [Fact]
    public void CheckExceptionForUpdateNullSpecialityTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "testRest";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            student.UpdateStudentSpeciality(null));
    }

    [Fact]
    public void UpdateSpecialityStudentTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        string speciality = "testRest";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        speciality += "Up";

        student.UpdateStudentSpeciality(speciality);

        Assert.True(student.Speciality == speciality);
        Assert.Contains("Up", student.Speciality);
    }

    [Fact]
    public void UpdateCourseStudentTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "testRest";
        var course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        course += +1;
        student.UpdateStudentCourse(course);

        Assert.True(student.Course == course);
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(6464)]
    public void CheckExceptionForUpdateCourseStudentTest(int courseUp)
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "testRest";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        IncorrectRangeException ex = Assert.Throws<IncorrectRangeException>(() =>
            student.UpdateStudentCourse(courseUp));
    }

    [Fact]
    public void CheckExceptionForZeroUpdateCourseStudentTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "testRest";
        var course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        course = 0;
        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            student.UpdateStudentCourse(course));
    }

    [Fact]
    public void CheckExceptionForInvalidId()
    {
        var studentId = Guid.Empty;
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "testRest";
        const int course = 4;

        IncorrectIdException ex = Assert.Throws<IncorrectIdException>(() =>
            new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }
}