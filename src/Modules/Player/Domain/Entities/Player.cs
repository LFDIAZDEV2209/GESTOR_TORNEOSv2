namespace GESTOR_TORNEOS.Domain.Entities;

public class Player : Person
{
    public required string Position { get; set; }
    public int? TeamId { get; set; }

    public Player(int id, string name, int age, string origin, string email, string position, int teamId) : base(id, name, age, origin, email)
    {
        Id = id;
        Name = name;
        Age = age;
        Origin = origin;
        Email = email;
        Position = position;
        TeamId = teamId;
    }

    public Player() { }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Age: {Age}, Origin: {Origin}, Email: {Email}, Position: {Position}, TeamId: {TeamId}";
    }
}



