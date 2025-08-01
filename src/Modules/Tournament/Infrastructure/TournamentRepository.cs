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
        var connection = _connection.GetConnection();
        string query = "DELETE FROM tournaments WHERE id = @id";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        return true;
    }

    public Tournament GetById(int id)
    {
        var connection = _connection.GetConnection();
        
        // Primero obtener los datos del torneo
        string query = "SELECT id, name, city, start_date, end_date FROM tournaments WHERE id = @id";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        using var reader = command.ExecuteReader();
        
        Tournament tournament;
        if (reader.Read())
        {
            tournament = new Tournament
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                City = reader.GetString(2),
                StartDate = reader.GetDateTime(3).Date,
                EndDate = reader.GetDateTime(4).Date,
                Teams = new List<Team>()
            };
        }
        else
        {
            throw new Exception("Torneo no encontrado");
        }
        
        // Cerrar el primer reader antes de abrir el segundo
        reader.Close();
        
        // Luego obtener los equipos del torneo
        string teamQuery = @"SELECT tm.id, tm.name, tm.city 
                            FROM teams tm
                            INNER JOIN tournament_teams tt ON tm.id = tt.team_id
                            WHERE tt.tournament_id = @tournamentId";

        using var teamCommand = new MySqlCommand(teamQuery, connection);
        teamCommand.Parameters.AddWithValue("@tournamentId", id);
        using var teamReader = teamCommand.ExecuteReader();
        
        while (teamReader.Read())
        {
            var team = new Team
            {
                Id = teamReader.GetInt32(0),
                Name = teamReader.GetString(1),
                City = teamReader.GetString(2)
            };
            tournament.Teams.Add(team);
        }
        
        return tournament;
    }

    public List<Tournament> GetAll()
    {
        var connection = _connection.GetConnection();
        string query = "SELECT id, name, city, start_date, end_date FROM tournaments";
        using var command = new MySqlCommand(query, connection);
        using var reader = command.ExecuteReader();
        
        var tournaments = new List<Tournament>();
        
        while (reader.Read())
        {
            tournaments.Add(new Tournament
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                City = reader.GetString(2),
                StartDate = reader.GetDateTime(3).Date,
                EndDate = reader.GetDateTime(4).Date,
                Teams = new List<Team>()
            });
        }
        
        return tournaments;
    }

    public bool Update(Tournament entity)
    {
        var connection = _connection.GetConnection();
        string query = "UPDATE tournaments SET name = @name, city = @city, start_date = @start_date, end_date = @end_date WHERE id = @id";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", entity.Id);
        command.Parameters.AddWithValue("@name", entity.Name);
        command.Parameters.AddWithValue("@city", entity.City);
        command.Parameters.AddWithValue("@start_date", entity.StartDate);
        command.Parameters.AddWithValue("@end_date", entity.EndDate);
        command.ExecuteNonQuery();
        return true;
    }
}