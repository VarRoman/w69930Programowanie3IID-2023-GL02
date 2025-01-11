namespace Projekt1._1.BasicObjects;
using System.Globalization;
// Player class that has all information about the specific player in each team with two dictionaries 
// and 3 methods for statistical information (and one override method)
public class Player : Person
{ 
    // Dictionary-property for general percentage of successful actions in each type of game technique
    private Dictionary<string, double> _playerInfromationStatistics = new Dictionary<string, double>
    {
        { "Attacks", 0 },
        { "Receive", 0 },
        { "Serves", 0 },
    };
    
    
    // Dictionary-property for calculating and preserving the information about the points, that this Player gained
    private Dictionary<string, int> _playerInfromationPoints = new Dictionary<string, int>
    {
        { "Attacks", 0 },
        { "Serves", 0 },
        { "Blocks", 0 }
    };

    
    // The constructor of the Manager class
    public Player(string name, string surname, int age, string gender, string wherefrom, string qualification, 
        string teamName) : base(name, surname, age, gender, wherefrom, qualification, teamName)
    {
    }
    
    
    // Statistical method for getting specific part of percentage information via key
    public double GetPlayerInformationStatistics(string key)
    {
        if (_playerInfromationStatistics.ContainsKey(key))
        {
            return _playerInfromationStatistics[key];
        }
        throw new ArgumentException("Invalid key provided.");
    }
    
    
    // Statistical method for getting specific part of points information via key
    public int GetPlayerInformationPoints(string key)
    {
        if (_playerInfromationPoints.ContainsKey(key))
        {
            return _playerInfromationPoints[key];
        }
        throw new ArgumentException("Invalid key provided.");
    }
    
    
    // Statistical method for getting a number of all points, scored by this Player
    public int GetPlayerInformationPointsTotal()
    {
        int total = 0;
        foreach (var key in _playerInfromationPoints.Keys)
        {
            total += _playerInfromationPoints[key];
        }
        return total;
    }
    
    
    // Override method for Player
    public override string GetOverallInformation()
    {
        return $"{base.GetOverallInformation()}\n\n" +
               $"Statistics:\n" +
               $"Attacks: {GetPlayerInformationStatistics("Attacks").ToString(CultureInfo.InvariantCulture)}\n" +
               $"Receives: {GetPlayerInformationStatistics("Receives").ToString(CultureInfo.InvariantCulture)}\n" +
               $"Serves: {GetPlayerInformationStatistics("Serves").ToString(CultureInfo.InvariantCulture)}\n\n" +
               $"Total points scored: {GetPlayerInformationPointsTotal().ToString()}";
    }
    
    
    // Method for giving a point in a random way to a player
    public void RandomScore()
    {
        Random rnd = new Random();
        double score = rnd.NextDouble();
        if (score < 0.33)
        {
            _playerInfromationPoints["Serves"]++;
        }

        if (score >= 0.33 && score < 0.66)
        {
            _playerInfromationPoints["Blocks"]++;
        }
        if (score >= 0.66)
        {
            _playerInfromationPoints["Attacks"]++;
        }
    }
}