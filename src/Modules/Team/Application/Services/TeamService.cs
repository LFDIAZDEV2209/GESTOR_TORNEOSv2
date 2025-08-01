using GESTOR_TORNEOS.Domain.Entities;
using GESTOR_TORNEOS.Domain.Ports;

namespace GESTOR_TORNEOS.Application.Services;

public class TeamService
{
    private readonly ITeamRepository _repo;

    public TeamService(ITeamRepository repo)
    {
        _repo = repo;
    }

    public void CreateTeam(Team team)
    {
        _repo.Add(team);
    }
    
}