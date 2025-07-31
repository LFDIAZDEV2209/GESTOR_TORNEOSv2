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
}