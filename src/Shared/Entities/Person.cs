namespace GESTOR_TORNEOS.Domain.Entities;

public class Person
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public required string Origin { get; set; }
    public required string Email { get; set; }

    public Person(int id, string name, int age, string origin, string email)
    {
        Id = id;
        Name = name;
        Age = age;
        Origin = origin;
        Email = email;
    }

    public Person() { }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Age: {Age}, Origin: {Origin}, Email: {Email}";
    }
}

