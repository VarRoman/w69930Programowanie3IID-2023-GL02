namespace Projekt1._1;
using System.Collections.Generic;
using BasicObjects;

internal class Program
{
    private static Data _data = new Data();
    public static List<Team> _teams = _data.Teams;
    private static Tournament _tournament = new Tournament();

    private static void ShowTeams()
    {
        Console.Clear();
        Console.WriteLine("Lista drużyn:");
        for (int i = 0; i < _teams.Count; i++)
        {
            Console.WriteLine($"{i}. {_teams[i].TeamName}");
        }
        Console.WriteLine("\nKliknij dowolny klawisz, aby kontynuować...");
        Console.ReadKey();
    }

    private static void AddTeam()
    {
        Console.Clear();
        if (_tournament.Winners.Count == 0)
        {
            Console.WriteLine("Wybierz drużynę z rezerwy, aby dodać:");
            var reserveTeams = _data.ReserveTeams;
            for (int i = 0; i < reserveTeams.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {reserveTeams[i].TeamName}");
            }
            Console.Write("Wybierz numer drużyny: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= reserveTeams.Count)
            {
                var selectedTeam = reserveTeams[choice - 1];
                if (!_teams.Contains(selectedTeam))
                {
                    _teams.Add(selectedTeam);
                    Console.WriteLine($"Drużyna {selectedTeam.TeamName} została dodana do turnieju.");
                }
                else
                {
                    Console.WriteLine("Drużyna już była podana wcześniej.");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy wybór.");
            }
            Console.WriteLine("\nKliknij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Turniej już się odbył.");
        }
    }

    private static void StartTournament()
    {
        if (_tournament.Winners.Count == 0)
        {
            foreach (var team in _teams)
            {
                _tournament.AddTeamFirstCycle(team);
            }

            Console.WriteLine("Rozpoczynamy turniej!");
            Task tournament = Task.Run(() => _tournament.StartTournament());
            Task.WaitAll(tournament);
            Console.WriteLine("Turniej już się skończył.");
        }
        else
        {
            Console.WriteLine("Turniej już się odbył.");
        }
        Console.WriteLine("\nKliknij dowolny klawisz, aby kontynuować...");
        Console.ReadKey();
    }

    private static void ShowResults()
    {
        Console.Clear();
        Console.WriteLine("Wyniki turnieju:");
        if (_tournament.Winners.ContainsKey(1))
        {
            Console.WriteLine($"Miejsce 1: {_tournament.Winners[1].TeamName}");
            Console.WriteLine($"Miejsce 2: {_tournament.Winners[2].TeamName}");
            Console.WriteLine($"Miejsce 3: {_tournament.Winners[3].TeamName}");
        }

        Console.WriteLine("\nKliknij dowolny klawisz, aby kontynuować...");
        Console.ReadKey();
    }

    private static void ShowPlayerStatistics()
    {
        Console.Clear();
        Console.Clear();
        Console.WriteLine("Wybierz drużynę:");
        for (int i = 0; i < _teams.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_teams[i].TeamName}");
        }
        
        Console.Write("Wybierz numer drużyny: ");
        if (int.TryParse(Console.ReadLine(), out int teamChoice) && teamChoice > 0 && teamChoice <= _teams.Count)
        {
            var selectedTeam = _teams[teamChoice - 1];
            Console.WriteLine($"Wybrano drużynę: {selectedTeam.TeamName}\n");
            
            Console.WriteLine("Wybierz zawodnika:");
            var players = new[] { "Setter", "Outside1", "Outside2", "Opposite", "Libero", "Middle1", "Middle2" };
            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {players[i]}");
            }

            Console.Write("Wybierz numer zawodnika: ");
            if (int.TryParse(Console.ReadLine(), out int playerChoice) && playerChoice > 0 && 
                playerChoice <= players.Length)
            {
                var player = selectedTeam.GetPlayerByPosition(players[playerChoice - 1]);
                Console.WriteLine($"Informacje o zawodniku:\n\n{player.GetOverallInformation()}");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy wybór zawodnika.");
            }
        }
        else
        {
            Console.WriteLine("Nieprawidłowy wybór drużyny.");
        }
        Console.WriteLine("\nKliknij dowolny klawisz, aby kontynuować...");
        Console.ReadKey();
    }

    public static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("   --   Turniej Siatkarski   --   ");
            Console.WriteLine("1. Wyświetl wszystkie drużyny");
            Console.WriteLine("2. Wyświetl informacje o graczu lub trenerze z pewnej drużyny");
            Console.WriteLine("3. Dodaj drużynę z rezerwy");
            Console.WriteLine("4. Rozpocznij turniej");
            Console.WriteLine("5. Wyświetl wyniki");
            Console.WriteLine("6. Zapisz dane do pliku");
            Console.WriteLine("7. Wczytaj dane z pliku");
            Console.WriteLine("0. Wyjdź");
            Console.Write("Wybierz opcję: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowTeams();
                    break;
                case "2":
                    ShowPlayerStatistics();
                    break;
                case "3":
                    AddTeam();
                    break;
                case "4":
                    StartTournament();
                    break;
                case "5":
                    ShowResults();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
                    break;
            }
        }
        Console.WriteLine("Dziękujemy za skorzystanie z aplikacji. Do zobaczenia!");
        
    }
}
