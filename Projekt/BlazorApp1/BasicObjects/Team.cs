namespace BlazorApp1.BasicObjects;

public class Team
{
    private string TeamName { get; set; }
    private Manager TeamManager { get; set; }
    private int RoundScore { get; set; }
    private int TeamTournamentPlace { get; set; }
    private string TeamRegistrationPlace { get; set; }
    private string[] TeamSponsors { get; set; }

    private Dictionary<string, Person> _teamDictionary = new Dictionary<string, Person>();

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

    public Person GetPlayer(string teamPosition)
    {
        if (_teamDictionary.ContainsKey(teamPosition))
        {
            return _teamDictionary[teamPosition];
        }

        throw new KeyNotFoundException("Invalid key provided.");
    }
}