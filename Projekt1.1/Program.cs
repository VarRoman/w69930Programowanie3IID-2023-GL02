namespace Projekt1._1;
using System.Collections.Generic;
using BasicObjects;

internal class Program
{
    public static void Main(string[] args)
    {
        Data data = new Data();
        List<Team> teams = data.Teams;
        
        Tournament tournament = new Tournament();
        
        foreach (var team in teams)
        {
            tournament.AddTeamFirstCycle(team);
        }
        
        Console.WriteLine("Rozpoczynamy turniej!");
        tournament.StartTournament();
        
        Console.WriteLine("Wyniki turnieju:");
        foreach (var winner in tournament.Winners)
        {
            Console.WriteLine($"Miejsce {winner.Key}: {winner.Value.TeamName}");
        }
    }
}
