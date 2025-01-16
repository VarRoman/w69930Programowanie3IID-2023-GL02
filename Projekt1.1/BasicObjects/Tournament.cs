using System.Text.RegularExpressions;

namespace Projekt1._1.BasicObjects;
using System;
using System.Threading.Tasks;

// Tournament class with all its main properties and methods(random results generating are also included)
public class Tournament
{
    private static readonly object _lock = new object();
    
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
        Console.WriteLine($"\nGra {firstTeam.TeamName} : {secondTeam.TeamName} w procesie");
        Thread.Sleep(100);
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

        lock (_lock)
        {
            Console.WriteLine($"\n        Wynik gry\n{firstTeam.TeamName} : {secondTeam.TeamName}\n");
            for (int i = 1; i <= match.TeamsScores.Count; i++)
            {
                Console.WriteLine($"#{i}   --    {match.TeamsScores[i][firstTeam.TeamName]} : " +
                                  $"{match.TeamsScores[i][secondTeam.TeamName]}   --    ");
            }
        }
    }

    public void PlayingTwoCourts(string currentcycleDestinatination, string cycleDestination)
    {
        for (int i = 0; i < TeamScheduleInfo[currentcycleDestinatination].Count / 4; i++)
        {
            var i1 = i;
            Task task1 = new Task(() => Match(TeamScheduleInfo[currentcycleDestinatination][i1 * 4], 
                TeamScheduleInfo[currentcycleDestinatination][i1 * 4 + 1], currentcycleDestinatination, 
                cycleDestination));
            Task task2 = new Task(() => Match(TeamScheduleInfo[currentcycleDestinatination][i1 * 4 + 2], 
                TeamScheduleInfo[currentcycleDestinatination][i1 * 4 + 3], currentcycleDestinatination, 
                cycleDestination));

            task1.Start();
            task2.Start();
            Task.WaitAll(task1, task2);
        }

        if (TeamScheduleInfo[currentcycleDestinatination].Count % 4 > 1)
        {
            Task task3 = new Task(() =>Match(TeamScheduleInfo[currentcycleDestinatination][^1],
                TeamScheduleInfo[currentcycleDestinatination][^2], currentcycleDestinatination, 
                cycleDestination));
            task3.Start();
            if (TeamScheduleInfo[currentcycleDestinatination].Count % 4 - 2 == 1)
            {
                TeamScheduleInfo[cycleDestination].Add(TeamScheduleInfo[currentcycleDestinatination][^3]);
            }
            Task.WaitAll(task3);
        }

        if (TeamScheduleInfo[currentcycleDestinatination].Count % 4 == 1)
        {
            TeamScheduleInfo[cycleDestination].Add(TeamScheduleInfo[currentcycleDestinatination][^1]);
        }
    }
    
    // Main method for getting random tournament results
    public void StartTournament()
    {
        Random rnd = new Random();
        // first_cycle -> quarter_final
        PlayingTwoCourts("first_cycle", "quarter_final");
        
        
        // shuffling the teams
        TeamScheduleInfo["quarter_final"] = TeamScheduleInfo["quarter_final"].OrderBy(x => rnd.Next()).ToList();
        
        
        // quarter_final -> semi_final
        PlayingTwoCourts("quarter_final", "semi_final");
        
        
        // shuffling the teams
        TeamScheduleInfo["semi_final"] = TeamScheduleInfo["semi_final"].OrderBy(x => rnd.Next()).ToList();
        
        
        // semi_final -> final and final
        Task task1 = new Task(() => Match(TeamScheduleInfo["semi_final"][0], TeamScheduleInfo["semi_final"][1], 
            "semi_final", "final"));
        task1.Start();
        if (TeamScheduleInfo["semi_final"].Count % 2 == 1)
        {
            Task task2 = new Task(() => Match(TeamScheduleInfo["semi_final"][2], 
                MatchInfoSchedule["quarter_final"][0].Loser, "semi_final", "final"));
            task2.Start();
            Task.WaitAll(task1, task2);
        }
        else
        {
            Task task2 = new Task(() => Match(TeamScheduleInfo["semi_final"][2], TeamScheduleInfo["semi_final"][3], 
                "semi_final", "final"));
            task2.Start();
            Task.WaitAll(task1, task2);
        }
        
        Match(MatchInfoSchedule["semi_final"][0].Loser, MatchInfoSchedule["semi_final"][1].Loser, 
            "prizers", "prizers");

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
    }
}