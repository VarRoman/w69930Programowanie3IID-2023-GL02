namespace BlazorApp1;

public class Team
{
    private string TeamName { get; set; }
    private int RoundScore { get; set; }
    private int TeamTournamentPlace { get; set; }
    private string TeamRegistrationPlace { get; set; }
    private string[] TeamSponsors { get; set; }

    private Dictionary<string, Player> _playersDictionary = new Dictionary<string, Player>();

    public Team(string teamName, string[] teamSponsors, string teamRegistrationPlace, Player setter, Player outside1, 
        Player outside2, Player opposite, Player libero, Player middle1, Player middle2)
    {
        TeamName = teamName;
        TeamSponsors = teamSponsors;
        TeamRegistrationPlace = teamRegistrationPlace;
        _playersDictionary.Add("Setter", setter);
        _playersDictionary.Add("Outside1", outside1);
        _playersDictionary.Add("Outside2", outside2);
        _playersDictionary.Add("Libero", libero);
        _playersDictionary.Add("Opposite", opposite);
        _playersDictionary.Add("Middle1", middle1);
        _playersDictionary.Add("Middle2", middle2);
    }

    public Player GetPlayer(string playerPosition)
    {
        if (_playersDictionary.ContainsKey(playerPosition))
        {
            return _playersDictionary[playerPosition];
        }
        throw new KeyNotFoundException("Invalid key provided.");
    }
}