using GESTOR_TORNEOS.Domain.Ports;

namespace GESTOR_TORNEOS.Shared.Factory;

public interface IDbFactory
{
    IPlayerRepository CreatePlayerRepository();
    ITeamRepository CreateTeamRepository();
    ITechnicalStaffRepository CreateTechnicalStaffRepository();
    ITournamentRepository CreateTournamentRepository();
    ITransferRepository CreateTransferRepository();
    IMedicalStaffRepository CreateMedicalStaffRepository();
}