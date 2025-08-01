using GESTOR_TORNEOS.Application.Services;
using GESTOR_TORNEOS.Application.UI;
using GESTOR_TORNEOS.Shared.Mysql;
using Spectre.Console;

namespace GESTOR_TORNEOS.Modules.MainMenu;

public class MainMenu
{
    private readonly TournamentUI _tournamentUI;
    private readonly TeamUI _teamUI;

    public MainMenu(string connectionString)
    {
        // Crear la factory
        var factory = new MySqlDbFactory(connectionString);
        
        // Crear servicios
        var tournamentService = new TournamentService(factory.CreateTournamentRepository());
        var teamService = new TeamService(factory.CreateTeamRepository());
        
        
        // Crear UIs
        _tournamentUI = new TournamentUI(tournamentService);
        _teamUI = new TeamUI(teamService);
    }

    public void Show()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Gestor de Torneos")
                .Centered()
                .Color(Color.Red)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]Seleccione una opción[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "0. Crear Torneo",
                    "1. Registro Equipos",
                    "2. Registro Jugadores",
                    "3. Transferencias (Compra, Préstamo)",
                    "4. Estadísticas",
                    "5. Salir"
                }));

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    _tournamentUI.ShowMenu();
                    break;
                case '1':
                    Console.Clear();
                    _teamUI.ShowMenu();
                    break;
                case '2':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de jugadores en desarrollo...[/]");
                    AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case '3':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de transferencias en desarrollo...[/]");
                    AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case '4':
                    Console.Clear();
                    AnsiConsole.MarkupLine("[yellow]Módulo de estadísticas en desarrollo...[/]");
                    AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case '5':
                    Console.Clear();
                    return;
                default:
                    AnsiConsole.MarkupLine("[bold red]Opción no válida[/]");
                    break;
            }
        }
    }
}