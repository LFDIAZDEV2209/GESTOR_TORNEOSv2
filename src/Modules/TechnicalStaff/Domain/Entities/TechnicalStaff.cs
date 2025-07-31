namespace GESTOR_TORNEOS.Domain.Entities;

public class TechnicalStaff : Person
{
    public required string Role { get; set; }
    public int TeamId { get; set; }

    public TechnicalStaff(int id, string name, int age, string origin, string email, string role, int teamId) : base(id, name, age, origin, email)
    {
        Id = id;
        Name = name;
        Age = age;
        Origin = origin;
        Email = email;
        Role = role;
        TeamId = teamId;
    }
    
    public TechnicalStaff() { }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Age: {Age}, Origin: {Origin}, Email: {Email}, Role: {Role}, TeamId: {TeamId}";
    }
}