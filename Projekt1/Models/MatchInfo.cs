namespace Projekt1.Models;

// Class for saving, processing and preserving the information about the match, also contains several methods for
// generating random match outcomes for testign purposes
public class MatchInfo
{
    // Properties for Match class, with some dictionaries about rounds score, points score of certein round and
    // overall information (#int - round, #string - team name, #int - points score)
    Random _rnd = new Random();
    public Team Team1 { get; set; }
    public Team Team2 { get; set; }
    public Team Winner { get; set; }
    public Team Loser { get; set; }
    public Dictionary<string, int> RoundsScores = new Dictionary<string, int>();
    public Dictionary<string, int> PointsScores = new Dictionary<string, int>();
    public Dictionary<int, Dictionary<string, int>> TeamsScores = new Dictionary<int, Dictionary<string, int>>();
    
    
    // The constructor of the MatchInfo class
    public MatchInfo(Team team1, Team team2)
    {
        Team1 = team1;
        Team2 = team2;
        RoundsScores.Add($"{Team1.TeamName}", 0);
        RoundsScores.Add($"{Team2.TeamName}", 0);
        PointsScores.Add($"{Team1.TeamName}", 0);
        PointsScores.Add($"{Team2.TeamName}", 0);
    }
    
    
    // Method for generating the round result randomly 
    public void DoTheRoundAuto()
    {
        PointsScores[Team1.TeamName] = 0;
        PointsScores[Team2.TeamName] = 0;
        
        while ((Math.Abs(PointsScores[Team1.TeamName] - PointsScores[Team2.TeamName]) < 2) &&
               (PointsScores.Values.Max() < 25))
        {
            double random = _rnd.NextDouble();
            if (random < 0.5)
            {
                PointsScores[Team1.TeamName]++;
                FindTheScorer(Team1);
            }
            else
            {
                PointsScores[Team2.TeamName]++;
                FindTheScorer(Team2);
            }
            
        }

        if (PointsScores.Values.Max() == PointsScores[Team1.TeamName])
        {
            RoundsScores[Team1.TeamName]++;
        }
        else
        {
            RoundsScores[Team2.TeamName]++;
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
            TeamsScores.Add(count, PointsScores);
        }

        if (RoundsScores.Values.Max() == RoundsScores[Team1.TeamName])
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

        if (random >= 0.2 && random < 0.4)
        {
            team.GetPlayerByPosition("Middle1").RandomScore();
        }
        
        if (random >= 0.4 && random < 0.6)
        {
            team.GetPlayerByPosition("Middle2").RandomScore();
        }
        
        if (random >= 0.6 && random < 0.8)
        {
            team.GetPlayerByPosition("Outside1").RandomScore();
        }
        
        if (random >= 0.8)
        {
            team.GetPlayerByPosition("Outside2").RandomScore();
        }
    }
    
}