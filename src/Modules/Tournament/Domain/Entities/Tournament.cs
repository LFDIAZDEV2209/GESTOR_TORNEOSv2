namespace GESTOR_TORNEOS.Domain.Entities;

public class Tournament
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string City { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public required List<Team> Teams { get; set; }

    public Tournament(int id, string name, string city, DateTime startDate, DateTime endDate, List<Team> teams)
    {
        Id = id;
        Name = name;
        City = city;
        StartDate = startDate;
        EndDate = endDate;
        Teams = teams;
    }

    public Tournament() { }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, City: {City}, StartDate: {StartDate}, EndDate: {EndDate}, Teams: {Teams}";
    }
}