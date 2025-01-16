namespace Projekt1._1.BasicObjects;

// Abstract class for Manager and Player, to not rewrite the same properties and for compatibility in the List objects
public abstract class Person
{
    // Basic properties for Person, Player, Manager
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Wherefrom { get; set; }
    public string Qualification { get; set; }
    public string TeamName { get; set; }
    public Team Team { get; set; }
    public int TeamId { get; set; }
    
    
    // The constructor of the Person class
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
    
    // An empty constructor
    protected Person()
    {
        throw new NotImplementedException();
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