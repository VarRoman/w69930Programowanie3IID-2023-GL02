namespace Projekt1._1.BasicObjects;

// Winner class for Database
public class Winner
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public Team Team { get; set; }
    public int Place { get; set; }
}
