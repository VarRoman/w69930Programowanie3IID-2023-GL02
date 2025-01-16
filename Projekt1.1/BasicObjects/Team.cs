namespace Projekt1._1.BasicObjects;

// Team class, that contains all the necessary information about the Players, Manager and their achievements, 
// also can be used for getting some information about the specific Player via his/her position or surname
public class Team
{
    // Some general properties for Team class
    public int Id { get; set; }
    public string Name { get; set; }
    public Manager TeamManager { get; set; }
    public int TeamTournamentPlace { get; set; }
    public string TeamRegistrationPlace { get; set; }
    public string[] TeamSponsors { get; set; }
    public List<Player> Players { get; set; }
    public Dictionary<string, Player> TeamDictionary { get; set; }
    
    public Team() { }

    // The constructor of the Team class
    [System.Text.Json.Serialization.JsonConstructor]
    public Team(string name, string[] teamSponsors, string teamRegistrationPlace, Player setter, Player outside1,
        Player outside2, Player opposite, Player libero, Player middle1, Player middle2, Manager teamManager)
    {
        Name = name;
        TeamSponsors = teamSponsors;
        TeamRegistrationPlace = teamRegistrationPlace;
        TeamManager = teamManager;
        TeamDictionary = new Dictionary<string, Player>
        {
            { "Setter", setter },
            { "Outside1", outside1 },
            { "Outside2", outside2 },
            { "Libero", libero },
            { "Opposite", opposite },
            { "Middle1", middle1 },
            { "Middle2", middle2 }
        };
    }
    
    // Method for getting a player via his/her position
    public Player GetPlayerByPosition(string teamPosition) 
    {
        if (TeamDictionary.ContainsKey(teamPosition))
        {
            return (Player)TeamDictionary[teamPosition];
        }

        throw new KeyNotFoundException("Invalid key provided.");
    }
    
    
    // Method for getting a player via his/her surname
    public Person GetPlayerBySurname(string surname) 
    {
        foreach (Person person in TeamDictionary.Values)
        {
            if (person.Surname == surname)
            {
                return person;
            }
        }

        throw new InvalidOperationException("Wrong surname.");
    }
}