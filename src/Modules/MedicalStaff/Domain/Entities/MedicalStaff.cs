namespace GESTOR_TORNEOS.Domain.Entities;

public class MedicalStaff : Person
{
    public required string Speciality { get; set; }
    public int TeamId { get; set; }

    public MedicalStaff(int id, string name, int age, string origin, string email, string speciality, int teamId) : base(id, name, age, origin, email)
    {
        Id = id;
        Name = name;
        Age = age;
        Origin = origin;
        Email = email;
        Speciality = speciality;
        TeamId = teamId;
    }

    public MedicalStaff() { }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Age: {Age}, Origin: {Origin}, Email: {Email}, Speciality: {Speciality}, TeamId: {TeamId}";
    }
}