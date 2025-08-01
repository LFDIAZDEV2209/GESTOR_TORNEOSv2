using Spectre.Console;
using GESTOR_TORNEOS.Application.Services;
using GESTOR_TORNEOS.Domain.Entities;

namespace GESTOR_TORNEOS.Application.UI;

public class TeamUI
{
    private readonly TeamService _service;

    public TeamUI(TeamService service)
    {
        _service = service;
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();

            AnsiConsole.Write(
                new FigletText("Equipos")
                .Centered()
                .Color(Color.Green)
            );

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[bold green]Que desea hacer?[/]")
                .AddChoices(new[]
                {
                    "1. Registrar Equipo",
                    "2. Registrar Cuerpo Tecnico",
                    "3. Registrar Cuerpo Medico",
                    "4. Inscripcion Torneo",
                    "5. Notificacion de Transferencia",
                    "6. Salir Torneo",
                    "7. Regresar al menu principal"
                })

            );

            switch (selection[0])
            {
                case '1':
                    CreateTeam();
                    break;
                case '2':
                    CreateTechnicalStaff();
                    break;
                case '3':
                    CreateMedicalStaff();
                    break;
                case '4':
                    RegisterTournament();
                    break;
                case '5':
                    NotifyTransfer();
                    break;
                case '6':
                    ExitTournament();
                    break;
                case '7':
                    return;
                default:
                    AnsiConsole.MarkupLine("[bold red]Opcion no valida[/]");
                    break;
            }
        }
    }

    private void CreateTeam()
    {
        var name = AnsiConsole.Ask<string>("[bold green]Nombre del equipo[/]");
        var city = AnsiConsole.Ask<string>("[bold green]Ciudad[/]");
        var team = new Team{
            Name = name,
            City = city,
            TournamentIds = new List<int>(),
            Players = new List<Player>(),
            MedicalStaff = new List<MedicalStaff>(),
            TechnicalStaff = new List<TechnicalStaff>()
        };
        _service.CreateTeam(team);
        AnsiConsole.MarkupLine($"[bold green]Equipo {name} creado correctamente[/]");
        AnsiConsole.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private void CreateTechnicalStaff()
    {
        throw new NotImplementedException();
    }

    private void CreateMedicalStaff()
    {
        throw new NotImplementedException();
    }

    private void RegisterTournament()
    {
        throw new NotImplementedException();
    }

    private void NotifyTransfer()
    {
        throw new NotImplementedException();
    }

    private void ExitTournament()
    {
        throw new NotImplementedException();
    }
}