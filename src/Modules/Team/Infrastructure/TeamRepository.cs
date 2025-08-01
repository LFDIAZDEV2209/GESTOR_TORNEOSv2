using GESTOR_TORNEOS.Domain.Entities;
using GESTOR_TORNEOS.Domain.Ports;
using GESTOR_TORNEOS.Shared.Mysql;
using MySql.Data.MySqlClient;

namespace GESTOR_TORNEOS.Infrastructure.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly SingletonConnection _connection;

    public TeamRepository(string connectionString)
    {
        _connection = SingletonConnection.GetInstance(connectionString);
    }

    public bool Add(Team entity)
    {
        var connection = _connection.GetConnection();
        string query = "INSERT INTO teams (name, city) VALUES (@name, @city)";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@name", entity.Name);
        command.Parameters.AddWithValue("@city", entity.City);
        command.ExecuteNonQuery();
        return true;
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Team GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Team> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Update(Team entity)
    {
        throw new NotImplementedException();
    }
}
