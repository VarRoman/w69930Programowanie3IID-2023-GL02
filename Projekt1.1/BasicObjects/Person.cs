using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Projekt1._1.BasicObjects;

// Abstract class for Manager and Player, to not rewrite the same properties and for compatibility in the List objects
[JsonObject]
public abstract class Person
{
    // Basic properties for Person, Player, Manager
    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("Surname")] 
    public string Surname { get; set; }

    [JsonPropertyName("Age")]
    public int Age { get; set; }

    [JsonPropertyName("Gender")]
    public string Gender { get; set; }

    [JsonPropertyName("Wherefrom")]
    public string Wherefrom { get; set; }

    [JsonPropertyName("Qualification")]
    public string Qualification { get; set; }

    [JsonPropertyName("TeamName")]
    public string TeamName { get; set; }
    
    
    // The constructor of the Person class
    [Newtonsoft.Json.JsonConstructor]
    protected Person(string name, string surname, int age, string gender, string wherefrom, string qualification, 
        string teamName)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Gender = gender;
        Wherefrom = wherefrom;
        Qualification = qualification;
        TeamName = teamName;
    }
    
    
    // Virtual method for classes Player and Manager to improve it later
    public virtual string GetOverallInformation()
    {
        return $"Name: {Name}\n" +
               $"Surname: {Surname}\n" +
               $"Age: {Age.ToString()}\n" +
               $"Gender {Gender}\n" +
               $"Wherefrom: {Wherefrom}\n" +
               $"Qualification: {Qualification}\n" +
               $"Teamname: {TeamName}\n";
    }
}