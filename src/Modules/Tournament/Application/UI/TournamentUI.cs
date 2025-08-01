using Spectre.Console;
using GESTOR_TORNEOS.Application.Services;
using GESTOR_TORNEOS.Domain.Entities;

namespace GESTOR_TORNEOS.Application.UI;

public class TournamentUI
{
    private readonly TournamentService _service;

    public TournamentUI(TournamentService service)
    {
        _service = service;
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Torneos")
                .Centered()
                .Color(Color.Yellow)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]¿Qué desea realizar?[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "0. Agregar Torneo",
                    "1. Buscar Torneo",
                    "2. Eliminar Torneo",
                    "3. Actualizar Torneo",
                    "4. Regresar al Menu Principal"
                })
            );

            switch (selection[0])
            {
                case '0':
                    Console.Clear();
                    AddTournament();
                    break;
                case '1':
                    Console.Clear();
                    SearchTournament();
                    break;
                case '2':
                    Console.Clear();
                    DeleteTournament();
                    break;
                case '3':
                    Console.Clear();
                    UpdateTournament();
                    break;
                case '4':
                    return;
                default:
                    AnsiConsole.MarkupLine("[bold red]Opción no válida[/]");
                    break;
            }
        }
    }

    private void AddTournament()
    {
        var name = AnsiConsole.Ask<string>("[bold green]Nombre del torneo[/]");
        var city = AnsiConsole.Ask<string>("[bold green]Ciudad[/]");
        var startDate = AnsiConsole.Ask<DateTime>("[bold green]Fecha de inicio[/]");
        var endDate = AnsiConsole.Ask<DateTime>("[bold green]Fecha de fin[/]");
        
        var tournament = new Tournament
        {
            Name = name,
            City = city,
            StartDate = startDate,
            EndDate = endDate,
            Teams = new List<Team>()
        };
        
        _service.CreateTournament(tournament);
    }

    private void SearchTournament()
    {
        var id = AnsiConsole.Ask<int>("[bold green]ID del torneo[/]");
        var tournament = _service.GetTournamentById(id);
        AnsiConsole.MarkupLine($"[bold green]Torneo encontrado:[/] {tournament.Name} - {tournament.City} - {tournament.StartDate:dd/MM/yyyy} - {tournament.EndDate:dd/MM/yyyy}");
        AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private void DeleteTournament()
    {
        var id = AnsiConsole.Ask<int>("[bold green]ID del torneo[/]");
        _service.DeleteTournament(id);
        AnsiConsole.MarkupLine($"[bold green]Torneo eliminado correctamente[/]");
        AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private void UpdateTournament()
    {
        throw new NotImplementedException();
    }
}