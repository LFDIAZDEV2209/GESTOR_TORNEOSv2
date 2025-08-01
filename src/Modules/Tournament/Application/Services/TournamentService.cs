using GESTOR_TORNEOS.Domain.Entities;
using GESTOR_TORNEOS.Domain.Ports;

namespace GESTOR_TORNEOS.Application.Services;

public class TournamentService
{
    private readonly ITournamentRepository _repo;

    public TournamentService(ITournamentRepository repo)
    {
        _repo = repo;
    }

    public void CreateTournament(Tournament tournament)
    {
        _repo.Add(tournament);
    }

    public Tournament GetTournamentById(int id)
    {
        return _repo.GetById(id);
    }

    public void DeleteTournament(int id)
    {
        _repo.Delete(id);
    }

    public List<Tournament> GetAllTournaments()
    {
        return _repo.GetAll();
    }
}