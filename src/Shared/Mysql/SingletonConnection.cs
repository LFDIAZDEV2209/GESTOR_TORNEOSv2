using MySql.Data.MySqlClient;

namespace GESTOR_TORNEOS.Shared.Mysql;

public class SingletonConnection
{
    private static SingletonConnection? _instance;
    private readonly string _connectionString;
    private MySqlConnection? _connection;

    private SingletonConnection(string connectionString)
    {
        _connectionString = connectionString;
    }

    public static SingletonConnection GetInstance(string connectionString)
    {
        _instance ??= new SingletonConnection(connectionString);
        return _instance;
    }

    public MySqlConnection GetConnection()
    {
        _connection ??= new MySqlConnection(_connectionString);

        if (_connection.State != System.Data.ConnectionState.Open)
            _connection.Open();

        return _connection;
    }
}