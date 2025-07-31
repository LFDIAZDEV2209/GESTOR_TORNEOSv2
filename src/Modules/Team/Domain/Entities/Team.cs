namespace GESTOR_TORNEOS.Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string City { get; set; }
    public required List<int> TournamentIds { get; set; }
    public required List<Player> Players { get; set; }
    public required List<MedicalStaff> MedicalStaff { get; set; }
    public required List<TechnicalStaff> TechnicalStaff { get; set; }

    public Team(int id, string name, string city, List<int>? tournamentIds, List<Player>? players, List<MedicalStaff>? medicalStaff, List<TechnicalStaff>? technicalStaff)
    {
        Id = id;
        Name = name;
        City = city;
        TournamentIds = tournamentIds ?? new List<int>();
        Players = players ?? new List<Player>();
        MedicalStaff = medicalStaff ?? new List<MedicalStaff>();
        TechnicalStaff = technicalStaff ?? new List<TechnicalStaff>();
    }

    public Team() { }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, City: {City}, TournamentIds: {TournamentIds}, Players: {Players}, MedicalStaff: {MedicalStaff}, TechnicalStaff: {TechnicalStaff}";
    }
}