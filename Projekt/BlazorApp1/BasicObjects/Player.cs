namespace BlazorApp1;

public class Player

{
    private string Name { get; set; }
    private string Surname { get; set; }
    private int Age { get; set; }
    private string Gender { get; set; }
    private string Position { get; set; }
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
    
    
    public Player(string name, string surname, int age, string gender, string position)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Gender = gender;
        Position = position;
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
    
}