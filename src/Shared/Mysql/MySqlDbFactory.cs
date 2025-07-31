using GESTOR_TORNEOS.Domain.Ports;
using GESTOR_TORNEOS.Shared.Factory;
using GESTOR_TORNEOS.Infrastructure.Repositories;

namespace GESTOR_TORNEOS.Shared.Mysql;

public class MySqlDbFactory : IDbFactory
{
    private readonly string _connectionString;

    public MySqlDbFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IPlayerRepository CreatePlayerRepository()
    {
        throw new NotImplementedException("PlayerRepository no implementado aún");
    }

    public ITeamRepository CreateTeamRepository()
    {
        throw new NotImplementedException("TeamRepository no implementado aún");
    }

    public ITechnicalStaffRepository CreateTechnicalStaffRepository()
    {
        throw new NotImplementedException("TechnicalStaffRepository no implementado aún");
    }

    public ITournamentRepository CreateTournamentRepository()
    {
        return new TournamentRepository(_connectionString);
    }

    public ITransferRepository CreateTransferRepository()
    {
        throw new NotImplementedException("TransferRepository no implementado aún");
    }

    public IMedicalStaffRepository CreateMedicalStaffRepository()
    {
        throw new NotImplementedException("MedicalStaffRepository no implementado aún");
    }
}