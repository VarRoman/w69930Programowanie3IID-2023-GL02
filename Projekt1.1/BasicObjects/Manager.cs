using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Projekt1._1.BasicObjects;

// Manager class for defining person who is responsible for bringing the team
// on the competition(it can also be coach, tutor or teacher, but the class will be the same)
[JsonObject]
public class Manager : Person
{
    // Property for Manager's stage in moths (int)
    [JsonPropertyName("CurrentTeamStandingMonths")]
    public int CurrentTeamStandingMonths { get; set; }
    
    
    // The constructor of the Manager class
    [System.Text.Json.Serialization.JsonConstructor]
    public Manager(string name, string surname, int age, string gender, string wherefrom, string qualification,
        string teamName, int currentTeamStandingMonths)
        : base(name, surname, age, gender, wherefrom, qualification, teamName)
    {
        CurrentTeamStandingMonths = currentTeamStandingMonths;
    }
    
    
    // Override method for Manager
    public override string GetOverallInformation()
    {
        return $"{base.GetOverallInformation()}\n\n" +
               $"With this team for {(CurrentTeamStandingMonths / 12).ToString()} years and" +
               $" {(CurrentTeamStandingMonths % 12).ToString()} months\n\n";
    }
}