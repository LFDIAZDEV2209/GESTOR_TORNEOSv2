using GESTOR_TORNEOS.Modules.MainMenu;
using GESTOR_TORNEOS.Shared.Mysql;

namespace GESTOR_TORNEOS;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var connectionString = "server=localhost;user=root;password=4m4rt3m4sn0pud3;database=gestor_torneos";
            
            // Inicializar SingletonConnection
            SingletonConnection.GetInstance(connectionString);
            
            // Crear el menú principal
            var mainMenu = new MainMenu(connectionString);
            
            // Mostrar el menú principal
            mainMenu.Show();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}