namespace GESTOR_TORNEOS.Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string City { get; set; }
    public List<int>? TournamentIds { get; set; }
    public List<Player>? Players { get; set; }
    public List<MedicalStaff>? MedicalStaff { get; set; }
    public List<TechnicalStaff>? TechnicalStaff { get; set; }

    public Team(int id, string name, string city, List<int>? tournamentIds, List<Player>? players, List<MedicalStaff>? medicalStaff, List<TechnicalStaff>? technicalStaff)
    {
        Id = id;
        Name = name;
        City = city;
        TournamentIds = tournamentIds;
        Players = players;
        MedicalStaff = medicalStaff;
        TechnicalStaff = technicalStaff;
    }

    public Team() { }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, City: {City}, TournamentIds: {TournamentIds}, Players: {Players}, MedicalStaff: {MedicalStaff}, TechnicalStaff: {TechnicalStaff}";
    }
}