using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Projekt1._1.BasicObjects;

// Class for saving, processing and preserving the information about the match, also contains several methods for
// generating random match outcomes for testign purposes
public class MatchInfo
{
    // Properties for Match class, with some dictionaries about rounds score, points score of certein round and
    // overall information (#int - round, #string - team name, #int - points score)
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; }
    public int Team1Id { get; set; }
    public int Team2Id { get; set; }
    public int WinnerId { get; set; }
    public int LoserId { get; set; }
    Random _rnd = new Random();
    public Team Team1 { get; set; }
    public Team Team2 { get; set; }
    public Team Winner { get; set; }
    public Team Loser { get; set; }
    public Dictionary<string, int> RoundsScores = new Dictionary<string, int>();
    public Dictionary<string, int> PointsScores = new Dictionary<string, int>();
    public Dictionary<int, Dictionary<string, int>> TeamsScores = new Dictionary<int, Dictionary<string, int>>();
    
    public MatchInfo() { }
    
    // The constructor of the MatchInfo class
    public MatchInfo(Team team1, Team team2)
    {
        Team1 = team1;
        Team2 = team2;
        RoundsScores.Add($"{Team1.Name}", 0);
        RoundsScores.Add($"{Team2.Name}", 0);
        PointsScores.Add($"{Team1.Name}", 0);
        PointsScores.Add($"{Team2.Name}", 0);
    }
    
    
    // Method for generating the round result randomly 
    public void DoTheRoundAuto()
    {
        PointsScores[Team1.Name] = 0;
        PointsScores[Team2.Name] = 0;
        
        while ((Math.Abs(PointsScores[Team1.Name] - PointsScores[Team2.Name]) < 2) || (PointsScores.Values.Max() < 25))
        {
            double random = _rnd.NextDouble();
            if (random < 0.5)
            {
                PointsScores[Team1.Name]++;
                FindTheScorer(Team1);
            }
            else
            {
                PointsScores[Team2.Name]++;
                FindTheScorer(Team2);
            }
            
        }

        if (PointsScores.Values.Max() == PointsScores[Team1.Name])
        {
            RoundsScores[Team1.Name]++;
        }
        else
        {
            RoundsScores[Team2.Name]++;
        }
    }
    
    
    // Method for generating random match result
    public Team DoTheMatchAuto()
    {
        int count = 0;
        while (RoundsScores.Values.Max() < 3)
        {
            DoTheRoundAuto();
            count++;
            TeamsScores.Add(count, new(PointsScores));
        }

        if (RoundsScores.Values.Max() == RoundsScores[Team1.Name])
        {
            Winner = Team1;
            Loser = Team2;
            return Team1;
        }
        Winner = Team2;
        Loser = Team1;
        return Team2;
    }
    
    // Helpful method for saving at least basic logic of this whole structure and adding point for a
    // random member of the team except of manager, setter and libero, whose main goals do not depend on point scoring 
    void FindTheScorer(Team team)
    {
        double random = _rnd.NextDouble();
        if (random < 0.2)
        {
            team.GetPlayerByPosition("Opposite").RandomScore();
        }

        else if (random >= 0.2 && random < 0.4)
        {
            team.GetPlayerByPosition("Middle1").RandomScore();
        }
        
        else if (random >= 0.4 && random < 0.6)
        {
            team.GetPlayerByPosition("Middle2").RandomScore();
        }
        
        else if (random >= 0.6 && random < 0.8)
        {
            team.GetPlayerByPosition("Outside1").RandomScore();
        }
        
        else if (random >= 0.8)
        {
            team.GetPlayerByPosition("Outside2").RandomScore();
        }
    }
    
}