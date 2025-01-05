namespace BlazorApp1.BasicObjects;

public abstract class Person
{
    private string Name { get; set; }
    private string Surname { get; set; }
    private int Age { get; set; }
    private string Gender { get; set; }
    private string Wherefrom {get; set;}
    private string Qualification { get; set; }
    
    protected Person(string name, string surname, int age, string gender, string wherefrom, string qualification)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Gender = gender;
        Wherefrom = wherefrom;
        Qualification = qualification;
    }

    public virtual string GetOverallInformation()
    {
        return $"Name: ${Name}\n" +
               $"Surname: ${Surname}\n" +
               $"Age: ${Age.ToString()}\n" +
               $"Gender ${Gender}\n" +
               $"Wherefrom: ${Wherefrom}\n" +
               $"Qualification: ${Qualification}";
    }
    
}