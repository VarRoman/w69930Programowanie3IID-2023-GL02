namespace BlazorApp1.BasicObjects;

// Abstract class for Manager and Player, to not rewrite the same properties and for compatibility in the List objects
public abstract class Person
{
    // Basic properties for Person, Player, Manager
    private string Name { get; set; }
    public string Surname { get; set; }
    private int Age { get; set; }
    private string Gender { get; set; }
    private string Wherefrom {get; set;}
    private string Qualification { get; set; }
    private string TeamName { get; set; }
    
    
    // The constructor of the Person class
    protected Person(string name, string surname, int age, string gender, string wherefrom, 
        string qualification, string teamName)
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