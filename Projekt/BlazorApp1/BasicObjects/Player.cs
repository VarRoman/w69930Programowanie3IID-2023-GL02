using System.Globalization;

namespace BlazorApp1.BasicObjects;

public class Player : Person
{ 
    private string TeamName { get; set; }
    
    private Dictionary<string, double> _playerInfromationStatistics = new Dictionary<string, double>
    {
        { "Attacks", 0 },
        { "Receive", 0 },
        { "Serves", 0 },
    };
    
    private Dictionary<string, int> _playerInfromationPoints = new Dictionary<string, int>
    {
        { "Attacks", 0 },
        { "Serves", 0 },
        {"Blocks", 0}
    };


    public Player(string name, string surname, int age, string gender, string wherefrom, string qualification, 
        string teamName) : base(name, surname, age, gender, wherefrom, qualification)
    {
        TeamName = teamName;
    }

    public double GetPlayerInformationStatistics(string key)
    {
        if (_playerInfromationStatistics.ContainsKey(key))
        {
            return _playerInfromationStatistics[key];
        }
        throw new ArgumentException("Invalid key provided.");
    }

    public int GetPlayerInformationPoints(string key)
    {
        if (_playerInfromationPoints.ContainsKey(key))
        {
            return _playerInfromationPoints[key];
        }
        throw new ArgumentException("Invalid key provided.");
    }

    public int GetPlayerInformationPointsTotal()
    {
        int total = 0;
        foreach (var key in _playerInfromationPoints.Keys)
        {
            total += _playerInfromationPoints[key];
        }
        return total;
    }
    
    public override string GetOverallInformation()
    {
        return $"{base.GetOverallInformation()}\n" +
               $"Teamname: ${TeamName}\n\n" +
               $"Statistics:\n" +
               $"Attacks: {GetPlayerInformationStatistics("Attacks").ToString(CultureInfo.InvariantCulture)}\n" +
               $"Receives: {GetPlayerInformationStatistics("Receives").ToString(CultureInfo.InvariantCulture)}\n" +
               $"Serves: {GetPlayerInformationStatistics("Serves").ToString(CultureInfo.InvariantCulture)}\n\n" +
               $"Total points scored: ${GetPlayerInformationPointsTotal().ToString()}";
    }
    
}