using GESTOR_TORNEOS.Domain.Entities;
using GESTOR_TORNEOS.Domain.Ports;
using GESTOR_TORNEOS.Shared.Mysql;
using MySql.Data.MySqlClient;

namespace GESTOR_TORNEOS.Infrastructure.Repositories;

public class TournamentRepository : ITournamentRepository
{
    private readonly SingletonConnection _connection;

    public TournamentRepository(string connectionString)
    {
        _connection = SingletonConnection.GetInstance(connectionString);
    }

    public bool Add(Tournament entity)
    {
        var connection = _connection.GetConnection();
        string query = "INSERT INTO tournaments (name, city, start_date, end_date) VALUES (@name, @city, @start_date, @end_date)";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@name", entity.Name);
        command.Parameters.AddWithValue("@city", entity.City);
        command.Parameters.AddWithValue("@start_date", entity.StartDate);
        command.Parameters.AddWithValue("@end_date", entity.EndDate);
        command.ExecuteNonQuery();
        return true;
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Tournament GetById(int id)
    {
        var connection = _connection.GetConnection();
        string query = "SELECT id, name, city, start_date, end_date FROM tournaments WHERE id = @id";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Tournament
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                City = reader.GetString(2),
                StartDate = reader.GetDateTime(3).Date,
                EndDate = reader.GetDateTime(4).Date,
                Teams = new List<Team>()
            };
        }
        throw new Exception("Torneo no encontrado");
    }

    public List<Tournament> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Update(Tournament entity)
    {
        throw new NotImplementedException();
    }
}