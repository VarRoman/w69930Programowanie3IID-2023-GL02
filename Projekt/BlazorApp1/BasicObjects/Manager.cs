namespace BlazorApp1.BasicObjects;

public class Manager : Person
{
    private string TeamName { get; set; }
    private int CurrentTeamStandingMonths { get; set; }
    public Manager(string name, string surname, int age, string gender, string wherefrom, string qualification, 
        string teamName, int currentTeamStandingMonths) : 
        base(name, surname, age, gender, wherefrom, qualification)
    {
        TeamName = teamName;
        CurrentTeamStandingMonths = currentTeamStandingMonths;
    }

    public override string GetOverallInformation()
    {
        return $"{base.GetOverallInformation()}\n" +
               $"Teamname: ${TeamName}\n" +
               $"With this team for ${(CurrentTeamStandingMonths / 12).ToString()} years and" +
               $" ${(CurrentTeamStandingMonths % 12).ToString()} months\n\n";
    }
}