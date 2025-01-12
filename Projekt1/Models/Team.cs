namespace Projekt1.Models;

// Team class, that contains all the necessary information about the Players, Manager and their achievements, 
// also can be used for getting some information about the specific Player via his/her position or surname
public class Team
{
    // Some general properties for Team class
    public string TeamName { get; set; }
    private Manager TeamManager { get; set; }
    public int TeamTournamentPlace { get; set; }
    private string TeamRegistrationPlace { get; set; }
    private string[] TeamSponsors { get; set; }

    private Dictionary<string, Person> _teamDictionary = new Dictionary<string, Person>();
    
    
    // The constructor of the Team class
    public Team(string teamName, string[] teamSponsors, string teamRegistrationPlace, Player setter, Player outside1, 
        Player outside2, Player opposite, Player libero, Player middle1, Player middle2, Manager teamManager)
    {
        TeamName = teamName;
        
        TeamSponsors = teamSponsors;
        TeamRegistrationPlace = teamRegistrationPlace;
        TeamManager = teamManager;
        _teamDictionary.Add("Manager", teamManager);
        _teamDictionary.Add("Setter", setter);
        _teamDictionary.Add("Outside1", outside1);
        _teamDictionary.Add("Outside2", outside2);
        _teamDictionary.Add("Libero", libero);
        _teamDictionary.Add("Opposite", opposite);
        _teamDictionary.Add("Middle1", middle1);
        _teamDictionary.Add("Middle2", middle2);
    }
    
    
    // Method for getting a player via his/her position
    public Player GetPlayerByPosition(string teamPosition) 
    {
        if (_teamDictionary.ContainsKey(teamPosition))
        {
            return (Player)_teamDictionary[teamPosition];
        }

        throw new KeyNotFoundException("Invalid key provided.");
    }
    
    
    // Method for getting a player via his/her surname
    public Person GetPlayerBySurname(string surname) 
    {
        foreach (Person person in _teamDictionary.Values)
        {
            if (person.Surname == surname)
            {
                return person;
            }
        }

        throw new InvalidOperationException("Wrong surname.");
    }
}