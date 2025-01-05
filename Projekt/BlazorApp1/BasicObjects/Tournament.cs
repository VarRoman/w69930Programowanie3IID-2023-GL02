using System;
using System.Threading.Tasks;

namespace BlazorApp1.BasicObjects;

public class Tournament
{
    public Dictionary<string, List<List<Team>>> Schedule = new Dictionary<string, List<List<Team>>>();
    public List<Team> Teams = new List<Team>();
    public List<Team> TeamSecondCycle = new List<Team>();

    public void AddTeam(Team team)
    {
        if (Teams.Contains(team))
        {
            Console.WriteLine("That team is already on the list!");
        }
        else if (Teams.Count < 16)
        {
            Teams.Add(team);
        }
        else
        {
            Console.WriteLine("There are already 16 teams on the list!");
        }
    }

    public Team Match(Team firstTeam, Team secondTeam)
    {
        Dictionary<string, int> roundsScores = new Dictionary<string, int>()
        {
            { $"{firstTeam.TeamName}", 0 },
            { $"{secondTeam.TeamName}", 0 },
        };
        
        Dictionary<string, int> pointsScores = new Dictionary<string, int>()
        {
            { $"{firstTeam.TeamName}", 0 },
            { $"{secondTeam.TeamName}", 0 },
        };
        while (roundsScores.Values.Max() < 3)
        {
            while ((Math.Abs(pointsScores[firstTeam.TeamName] - pointsScores[secondTeam.TeamName]) < 2) &&
                   (pointsScores.Values.Max() < 25))
            {
                
            }
        }
        
        
        return firstTeam;
    }
    
    public void StartTournament()
    {
        
        
        
        
        for (int i = 0; i < Teams.Count / 4; i++)
        {
            var i1 = i;
            Thread thread1 = new Thread(() => Match(Teams[i1 * 4], Teams[i1 * 4 + 1]));
            Thread thread2 = new Thread(() => Match(Teams[i1 * 4 + 2], Teams[i1 * 4 + 3]));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        if (Teams.Count % 4 > 1)
        {
            Thread thread1 = new Thread(() => Match(Teams[^1], Teams[^2]));
            thread1.Start();
            thread1.Join();
        }
    }
}