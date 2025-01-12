namespace Projekt1._1.BasicObjects;
using System;
using System.Threading.Tasks;

// Tournament class with all its main properties and methods(random results generating are also included)
public class Tournament
{
    // Dictionary-property for getting match results
    public Dictionary<string, List<MatchInfo>> MatchInfoSchedule = new Dictionary<string, List<MatchInfo>>()
    {
        { "first_cycle", new List<MatchInfo>()},
        { "quarter_final", new List<MatchInfo>()},
        { "semi_final", new List<MatchInfo>()},
        { "final", new List<MatchInfo>()},
        { "prizers", new List<MatchInfo>()}
    };

    
    // Dictionary-property for getting cycle information about the teams(which team where participated)
    public Dictionary<string, List<Team>> TeamScheduleInfo = new Dictionary<string, List<Team>>()
    {
        { "first_cycle", new List<Team>()},
        { "quarter_final", new List<Team>()},
        { "semi_final", new List<Team>()},
        { "final", new List<Team>()},
        { "prizers", new List<Team>()}
    };
    
    
    // Defining empty Dictionary-property for winners
    public Dictionary<int, Team> Winners { get; set; } = new Dictionary<int, Team>();
    
    
    // Basic method for addding teams on the first_cycle
    public void AddTeamFirstCycle(Team team)
    {
        if (TeamScheduleInfo["first_cycle"].Contains(team))
        {
            Console.WriteLine("That team is already on the list!");
        }
        else if (TeamScheduleInfo["first_cycle"].Count < 16)
        {
            TeamScheduleInfo["first_cycle"].Add(team);
        }
        else
        {
            Console.WriteLine("There are already 16 teams on the list!");
        }
    }

    
    // One of the main methods, which also is used for multithreading
    public void Match(Team firstTeam, Team secondTeam, string currentcycleDestinatination, string cycleDestination)
    {
        MatchInfo match = new MatchInfo(firstTeam, secondTeam);
        Console.WriteLine("Gra w procesie");
        Thread.Sleep(3000);
        if (cycleDestination == "prizers")
        {
            TeamScheduleInfo[cycleDestination].Add(match.DoTheMatchAuto());
            TeamScheduleInfo[cycleDestination].Add(match.Loser);
        }
        else
        {
            TeamScheduleInfo[cycleDestination].Add(match.DoTheMatchAuto());
        }
        MatchInfoSchedule[currentcycleDestinatination].Add(match);
        
        Console.WriteLine($"Wynik gry\n{firstTeam.TeamName} : {secondTeam.TeamName}\n");
        for (int i = 1; i <= match.TeamsScores.Count; i++)
        {
            Console.WriteLine($"#{i}   --    {match.TeamsScores[i][firstTeam.TeamName]} : " +
                              $"{match.TeamsScores[i][secondTeam.TeamName]}   --    ");
        }
    }
    
    
    // Main method for getting random tournament results
    public void StartTournament()
    {
        Random rnd = new Random();
        // first_cycle -> quarter_final
        for (int i = 0; i < TeamScheduleInfo["first_cycle"].Count / 4; i++)
        {
            var i1 = i;
            Thread thread1 = new Thread(() => Match(TeamScheduleInfo["first_cycle"][i1 * 4], 
                        TeamScheduleInfo["first_cycle"][i1 * 4 + 1], "first_cycle", 
                        "quarter_final"));
            Thread thread2 = new Thread(() => Match(TeamScheduleInfo["first_cycle"][i1 * 4 + 2], 
                        TeamScheduleInfo["first_cycle"][i1 * 4 + 3], "first_cycle", 
                        "quarter_final"));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        if (TeamScheduleInfo["first_cycle"].Count % 4 > 1)
        {
            Thread thread1 = new Thread(() => Match(TeamScheduleInfo["first_cycle"][^1],
                TeamScheduleInfo["first_cycle"][^2], "first_cycle", "quarter_final"));
            if (TeamScheduleInfo["first_cycle"].Count % 4 - 2 == 1)
            {
                TeamScheduleInfo["quarter_final"].Add(TeamScheduleInfo["first_cycle"][^3]);
            }
            thread1.Start();
            thread1.Join();
        }
        
        
        // shuffling the teams
        TeamScheduleInfo["quarter_final"] = TeamScheduleInfo["quarter_final"].OrderBy(x => rnd.Next()).ToList();
        
        
        // quarter_final -> semi_final
        for (int i = 0; i < TeamScheduleInfo["quarter_final"].Count / 2; i++)
        {
            var i2 = i;
            Match(TeamScheduleInfo["quarter_final"][i2 * 2], 
                TeamScheduleInfo["quarter_final"][i2 * 2 + 1], "quarter_final", 
                "semi_final");
        }

        if (TeamScheduleInfo["quarter_final"].Count % 2 == 1)
        {
            TeamScheduleInfo["semi_final"].Add(TeamScheduleInfo["quarter_final"][^1]);
        }
        
        // shuffling the teams
        TeamScheduleInfo["semi_final"] = TeamScheduleInfo["semi_final"].OrderBy(x => rnd.Next()).ToList();
        
        // semi_final -> final and final
        Match(TeamScheduleInfo["semi_final"][0], TeamScheduleInfo["semi_final"][1], "semi_final", 
            "final");
        if (TeamScheduleInfo["semi_final"].Count % 2 == 1)
        {
            TeamScheduleInfo["final"].Add(TeamScheduleInfo["semi_final"][^1]);
            Match(MatchInfoSchedule["semi_final"][0].Loser, MatchInfoSchedule["quarter_final"][0].Loser, 
                "prizers", "prizers");
        }
        else
        {
            Match(TeamScheduleInfo["semi_final"][2], TeamScheduleInfo["semi_final"][3], "semi_final", 
            "final");
            Match(MatchInfoSchedule["semi_final"][0].Loser, MatchInfoSchedule["semi_final"][1].Loser, 
                "prizers", "prizers");
        }

        MatchInfoSchedule["prizers"][0].Loser.TeamTournamentPlace = 4;
        MatchInfoSchedule["prizers"][0].Winner.TeamTournamentPlace = 3;
        TeamScheduleInfo["prizers"].Remove(MatchInfoSchedule["prizers"][0].Loser);
        
        
        Match(TeamScheduleInfo["final"][0], TeamScheduleInfo["final"][1], "final", 
            "prizers");
        
        MatchInfoSchedule["final"][0].Loser.TeamTournamentPlace = 2;
        MatchInfoSchedule["final"][0].Winner.TeamTournamentPlace = 1;
        
        // setting the winners
        foreach (Team team in TeamScheduleInfo["prizers"])
        {
            Winners.Add(team.TeamTournamentPlace, team);
        }

        Console.ReadKey();
        Console.WriteLine("\nKliknij dowolny klawisz, aby kontynuować...");
    }
}