namespace GESTOR_TORNEOS.Domain.Entities;

public class Tournament
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Team>? Teams { get; set; }

    public Tournament(int id, string name, string city, DateTime startDate, DateTime endDate, List<Team>? teams = null)
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
        return $"Id: {Id}, Name: {Name}, City: {City}, StartDate: {StartDate:yyyy-MM-dd}, EndDate: {EndDate:yyyy-MM-dd}, Teams: {Teams}";
    }
}