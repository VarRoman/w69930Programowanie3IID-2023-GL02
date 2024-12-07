
namespace Lab2;

public class Osoba
{
    public static int Ilosc = 8;
    private static string Name { get; set; }
    private static string Surname { get; set; }
    private static int Age { get; set; }
    private static string Pesel { get; } = "12345678888";

    public Osoba(string name, string surname, int age)
    {
        Name = name;
        Surname = surname;
        Age = age;
        if (Age < 0)
        {
            Age = 0;
        }
    }

    public string Introduction()
    {
        return $"Nazywam się {Name} {Surname} i mam {Age} lat";
    }

    public static void Main(string[] args)
    {
        //zadanie 1
        Console.WriteLine("\nZadanie #1");
        Osoba obj = new Osoba("Roman", "Bezshchasnyi", 19);
        Console.WriteLine(obj.Introduction());
        
        //zadanie 2
        Console.WriteLine("\nZadanie #2");
        Licz obj1 = new Licz(30);
        obj1.Addition(60);
        obj1.Subtraction(25);
        Console.WriteLine(obj1.ShowValue());
        
        //zadanie 3
        Console.WriteLine("\nZadanie #3");
        Licz[] liczba = new Licz[Ilosc];
        for (int i = 0; i < Ilosc; i++)
        {
            liczba[i] = new Licz(i);
        }
        Sumator obj2 = new Sumator(liczba);
        
        Console.WriteLine("Suma zwracającą sumę liczb z pola Liczby: " + obj2.Suma());
        Console.WriteLine("SumaPodziel3 zwracającą sumę liczb z tablicy, które są podzielne przez 3: " + obj2.SumaPodziel3());
        Console.WriteLine("IleElementów() zwracającej liczbę elementów na w tablicy: " + obj2.IleElementów());
        Console.WriteLine("ShowElements() wypisującą wszystkie elementy tablicy: ");
        obj2.ShowElements();
		Console.WriteLine("ShowFromIndexes wypisującą wszystkie elementy tablicy pomiędzy lowindex" +  
		 " i highindex parametrami: ");
        obj2.ShowFromIndexes(2, 5);
    }
}

public class Licz
{
    private int Number { get; set; }

    public Licz(int number)
    {
        Number = number;
    }   
    public void Addition(int param)
    {
        Number += param;
    }

    public void Subtraction(int param)
    {
        Number -= param;
    }

    public int ShowValue()
    {
        return Number;
    }
}

public class Sumator
{
    private static Licz[] Liczba;

    public Sumator(Licz[] liczba)
    {   
        Liczba = liczba;
        
    }
    public int Suma()
    {
        int sum = 0;
        for (int i = 0; i < Liczba.Length; i++)
        {
            Licz licz = Liczba[i];
            sum += licz.ShowValue();
        }
        return sum;
    }

    public int SumaPodziel3()
    {
        int suma = 0;
        foreach (Licz licz in Liczba)
        {
            if (suma % 3 == 0)
            {
                suma += licz.ShowValue();
            }
        }
        return suma;
    }

    public int IleElementów()
    {
        return Liczba.Length;
    }

    public void ShowElements()
    {
        for (int i = 0; i < Liczba.Length; i++)
        {
            Console.WriteLine($"Element {Liczba[i]} ma index {i} w Liczba[] i " +
                              $"Number ma wartość = {Liczba[i].ShowValue()}");
            
        }
    }

    public void ShowFromIndexes(int lowindex, int highindex)
    {
        if (lowindex < 0)
        {
            lowindex = 0;
        }

        if (highindex >= Liczba.Length)
        {
            highindex = Liczba.Length - 1;
        }

        for (int i = lowindex; i <= highindex; i++)
        {
            Console.WriteLine($"Element {Liczba[i]} ma index {i} w Liczba[] i " +
                              $"Number ma wartość = {Liczba[i].ShowValue()}");
        }
    }
}