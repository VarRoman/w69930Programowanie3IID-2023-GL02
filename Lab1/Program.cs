using System.Xml;

namespace Lab1;

public class Program
{
    static void FirsTask()
    {
        Console.WriteLine("Enter your value");
        Console.WriteLine((int.Parse(Console.ReadLine()) % 2 == 0) ? "Even" : "Not even");
    }

    static void SecondTask()
    {
        Console.WriteLine("Enter your value");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }

    static void ThirdTask()
    {
        Console.WriteLine("Enter your choice from the menu (1, 2, 4 or 5) or enter word Wyjscie");
        string n = Console.ReadLine();
        while (n != "Wyjscie")
        {
            switch (n)
            {
                case "1":
                    FirsTask();
                    break;
                
                case "2":
                    SecondTask();
                    break;
                
                case "4":
                    Console.WriteLine("Enter the value to get the factorial of it");
                    int factorial = int.Parse(Console.ReadLine());
                    Console.WriteLine(FourthTask(factorial));
                    break;
                
                case "5":
                    FifthTask();
                    break;
                
                default:
                    Console.WriteLine("You have entered wrong value");
                    break;
            }
            Console.WriteLine("Enter your choice from the menu (1, 2, 4 or 5) or enter word Wyjscie");
            n = Console.ReadLine();
        }
    }

    static int FourthTask(int n)
    {
        if (n != 1)
        {
            n *= FourthTask(n - 1);
        }

        return n;

    }

    static void FifthTask()
    {
        int countTry = 0;
        Random random = new Random();
        int randomNumber = random.Next(0, 51);
        Console.WriteLine("Try to guess the random number");
        int guess = int.Parse(Console.ReadLine());
        while (guess != randomNumber)
        {
            if (guess > randomNumber)
            {
                Console.WriteLine("Probably close, but you got too far...");
            }
            else
            {
                Console.WriteLine("Probably close, but that was still too low");
            }
            countTry++;
            guess = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("You have finally guessed right! And the number of guesses was " + countTry + " times!");
    }
    
    
    static void Main(string[] args)
    {
        // FirsTask();
        // SecondTask();
        ThirdTask();
        // Console.WriteLine("Enter the value to get the factorial of it");
        // int factorial = int.Parse(Console.ReadLine());
        // Console.WriteLine(FourthTask(factorial));
        // FifthTask();
    }

}