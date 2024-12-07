using System;

namespace Lab4
{
    public class Osoba
    {
        public static int Ilosc = 8;
        public string Name { get; set; }
        public char plec;

        public char Plec
        {
            get { return plec;}
            set
            {
                if ((int)char.GetNumericValue(value) % 2 == 1)
                {
                    plec = 'M';
                }
                else
                {
                    plec = 'D';
                }
            }
        }
        
        public bool MozeSamWrocicDoDomu { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Pesel { get; set;  }

        public Osoba(string name, string surname, int age, string pesel)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Plec = pesel[9];
            Pesel = pesel;
            if (Age < 0)
            {
                Age = 0;
            }
        }

        public string Introduction()
        {
            return $"Nazywam się {Name} {Surname} i mam {Age} lat, {plec}";
        }
        
        public virtual void pobierzInformacjeOEdukacji(Osoba osoba)
        {
            Console.WriteLine($"Osoba nazywa się {osoba.Name} {osoba.Surname} i ma {osoba.Age} lat, " +
                              $"oraz studiuje w szkole");
        }

        public virtual bool czyMozeSamWrocicDoDomu(Osoba osoba)
        {
            if (osoba.Age < 12 && osoba.MozeSamWrocicDoDomu == false)
            {
                return false;
            }
            return true;
        }
    }

    public class Uczen : Osoba
    {
        public string Szkola { get; set; }
        
        public Uczen(string name, string surname, int age, string szkola,
            bool mozeSamWrocicDoDomu, string pesel) : base(name, surname, age, pesel)
        {
            Szkola = szkola;
            MozeSamWrocicDoDomu = mozeSamWrocicDoDomu;
        }

        public void ustawSzkole(Uczen uczen, string szkola)
        {
            uczen.Szkola = szkola;
        }

        public void zmienSzkole(Uczen uczen, string szkola)
        {
            uczen.Szkola = szkola;
        }

        public void ustawCzyMozeSamWrocic(Uczen uczen, bool mozna)
        {
            uczen.MozeSamWrocicDoDomu = mozna;
        }

        public void informacje(Uczen uczen)
        {
            Console.WriteLine(uczen is { Age: < 12, MozeSamWrocicDoDomu: false }
                ? "Uczeń nie może wracać samodzielnie"
                : "Uczeń może wracać samodzielnie");
        }
        
        public override void pobierzInformacjeOEdukacji(Osoba osoba)
        {
            Uczen uczen = (Uczen)osoba;
            Console.WriteLine($"Osoba nazywa się {osoba.Name} {osoba.Surname} i ma {osoba.Age} lat, " +
                              $"oraz studiuje w szkole №{uczen.Szkola}");
        }
        
        public override bool czyMozeSamWrocicDoDomu(Osoba osoba)
        {
            if (osoba.Age < 12 && osoba.MozeSamWrocicDoDomu == false)
            {
                return false;
            }
            return true;
        }
    }

    public class Nauczyciel : Osoba
    {
        public string tytulNaukowy { get; set; }
        public List<Uczen> uczniowieKlasy = new List<Uczen>();
        
        public Nauczyciel(string name, string surname, int age,
            string tytulNaukowy, string pesel) : base(name, surname, age, pesel)
        {
            this.tytulNaukowy = tytulNaukowy;
        }

        public void dodajUcznia(Uczen uczen)
        {
            uczniowieKlasy.Add(uczen);
        }

        public List<string> ktorzyUcziowieMogaWrocicSamodzielnie()
        {
            List<string> mogaUczniowie = new List<string>();
            foreach (Uczen uczen in uczniowieKlasy)
            {
                if (uczen.czyMozeSamWrocicDoDomu(uczen))
                {
                    mogaUczniowie.Add($"{uczen.Introduction()}");
                }
            }
            
            return mogaUczniowie;
        }

        public void podsumowanieKlasy(Nauczyciel nauczyciel, string data)
        {

            Console.WriteLine($"Dnia {data}\n" +
                              $"Nauczyciel: {tytulNaukowy} {Name} {Surname}\n" + "Lista studentów:");
            foreach (Uczen uczen in uczniowieKlasy)
            {
                Console.WriteLine($"{uczen.Name} {uczen.Surname} - Plec: {uczen.Plec} - " +
                                  $"Ocena: {new Random().NextInt64(0, 100)} - Wynik: {"Nie wiem z jakiej przyczyny"}");
            }                  
            
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Zadanie 1");
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Circle(1, 2, 3, 4 ));
            shapes.Add(new Triangle(5, 6, 7, 8));
            shapes.Add(new Rectangle(9, 10, 11, 12));
            shapes[0].Draw();
            shapes[1].Draw();
            shapes[2].Draw();
            
            Console.WriteLine("\nZadanie 2");
            Uczen uczen1 = new Uczen("Roman", "Bezshchsnyi", 19, 
                "76", true, "22345678910");
            // uczen1.informacje(uczen);
            Uczen uczen2 = new Uczen("Rostik", "Yaremko", 18, 
                "32", false, "12333378910");
            Nauczyciel nauczyciel = new Nauczyciel("Damian", "Kontek", 25,
                "inz", "11111678910");
            nauczyciel.dodajUcznia(uczen1);
            nauczyciel.dodajUcznia(uczen2);
            nauczyciel.podsumowanieKlasy(nauczyciel, "07.12.2024");
            
        }
    }
}

