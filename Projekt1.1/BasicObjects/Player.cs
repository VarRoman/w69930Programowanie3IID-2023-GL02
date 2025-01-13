using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Projekt1._1.BasicObjects;
using System.Globalization;
// Player class that has all information about the specific player in each team with two dictionaries 
// and 3 methods for statistical information (and one override method)
[JsonObject]
public class Player : Person
{
    // Dictionary-property for general percentage of successful actions in each type of game technique
    public Dictionary<string, double> PlayerInformationStatistics { get; set; } = new Dictionary<string, double>()
    {
        { "Attacks", 0 },
        { "Receives", 0 },
        { "Serves", 0 },
    };

    // Dictionary-property for calculating and preserving the information about the points, that this Player gained
    public Dictionary<string, int> PlayerInformationPoints { get; set; } = new Dictionary<string, int>()
    {
        { "Attacks", 0 },
        { "Serves", 0 },
        { "Blocks", 0 }
    };

    
    // The constructor of the Manager class
    [Newtonsoft.Json.JsonConstructor]
    public Player(string name, string surname, int age, string gender, string wherefrom, string qualification, 
        string teamName, Dictionary<string, double> statistics = null, Dictionary<string, int> points = null) 
        : base(name, surname, age, gender, wherefrom, qualification, teamName)
    {
        if (statistics != null)
        {
            PlayerInformationStatistics = statistics;
        }

        if (points != null)
        {
            PlayerInformationPoints = points;
        }
    }
    
    
    // Statistical method for getting specific part of percentage information via key
    public double GetPlayerInformationStatistics(string key)
    {
        if (PlayerInformationStatistics.ContainsKey(key))
        {
            return PlayerInformationStatistics[key];
        }
        throw new ArgumentException("Invalid key provided.");
    }
    
    
    // Statistical method for getting specific part of points information via key
    public int GetPlayerInformationPoints(string key)
    {
        if (PlayerInformationPoints.ContainsKey(key))
        {
            return PlayerInformationPoints[key];
        }
        throw new ArgumentException("Invalid key provided.");
    }
    
    
    // Statistical method for getting a number of all points, scored by this Player
    public int GetPlayerInformationPointsTotal()
    {
        int total = 0;
        foreach (var key in PlayerInformationPoints.Keys)
        {
            total += PlayerInformationPoints[key];
        }
        return total;
    }
    
    
    // Override method for Player
    public override string GetOverallInformation()
    {
        return $"{base.GetOverallInformation()}\n" +
               $"Statistics:\n" +
               $"Attacks: {GetPlayerInformationPoints("Attacks")}\n" +
               $"Blocks: {GetPlayerInformationPoints("Blocks")}\n" +
               $"Serves: {GetPlayerInformationPoints("Serves")}\n\n" +
               $"Total points scored: {GetPlayerInformationPointsTotal().ToString()}";
    }
    
    
    // Method for giving a point in a random way to a player
    public void RandomScore()
    {
        Random rnd = new Random();
        double score = rnd.NextDouble();
        if (score < 0.33)
        {
            PlayerInformationPoints["Serves"]++;
        }

        if (score >= 0.33 && score < 0.66)
        {
            PlayerInformationPoints["Blocks"]++;
        }
        if (score >= 0.66)
        {
            PlayerInformationPoints["Attacks"]++;
        }
    }
}