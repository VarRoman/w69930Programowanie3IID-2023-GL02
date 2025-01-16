namespace Projekt1._1;
using BasicObjects;

public class Data
{ 
    private List<Team> _teams = new List<Team>
    {
        new Team(
            "Wilki Warszawy",
            new[] {"Sponsor1", "Sponsor2"},
            "Warszawa",
            new Player("Jan", "Kowalski", 25, "M", "Warszawa", "Profesjonalista", "Wilki Warszawy"),
            new Player("Piotr", "Nowak", 22, "M", "Kraków", "Zaawansowany", "Wilki Warszawy"),
            new Player("Tomasz", "Wiśniewski", 27, "M", "Łódź", "Ekspert", "Wilki Warszawy"),
            new Player("Marek", "Dąbrowski", 23, "M", "Poznań", "Profesjonalista", "Wilki Warszawy"),
            new Player("Krzysztof", "Wójcik", 30, "M", "Gdańsk", "Ekspert", "Wilki Warszawy"),
            new Player("Adam", "Kamiński", 24, "M", "Szczecin", "Zaawansowany", "Wilki Warszawy"),
            new Player("Paweł", "Lewandowski", 29, "M", "Lublin", "Profesjonalista", "Wilki Warszawy"),
            new Manager("Jakub", "Zieliński", 35, "M", "Warszawa", "Trener", "Wilki Warszawy", 36)
        ),
        new Team(
            "Lwy Krakowa",
            new[] {"Sponsor3", "Sponsor4"},
            "Kraków",
            new Player("Anna", "Kowalczyk", 26, "F", "Kraków", "Profesjonalista", "Lwy Krakowa"),
            new Player("Katarzyna", "Nowicka", 23, "F", "Warszawa", "Zaawansowany", "Lwy Krakowa"),
            new Player("Julia", "Wiśniewska", 28, "F", "Łódź", "Ekspert", "Lwy Krakowa"),
            new Player("Magdalena", "Dąbrowska", 24, "F", "Poznań", "Profesjonalista", "Lwy Krakowa"),
            new Player("Agnieszka", "Wójcik", 31, "F", "Gdańsk", "Ekspert", "Lwy Krakowa"),
            new Player("Joanna", "Kamińska", 25, "F", "Szczecin", "Zaawansowany", "Lwy Krakowa"),
            new Player("Zofia", "Lewandowska", 30, "F", "Lublin", "Profesjonalista", "Lwy Krakowa"),
            new Manager("Michał", "Zieliński", 38, "M", "Kraków", "Trener", "Lwy Krakowa", 48)
        ),
        new Team(
            "Orły Poznania",
            new[] {"Sponsor5", "Sponsor6"},
            "Poznań",
            new Player("Grzegorz", "Malinowski", 24, "M", "Poznań", "Profesjonalista", "Orły Poznania"),
            new Player("Rafał", "Pawłowski", 23, "M", "Warszawa", "Zaawansowany", "Orły Poznania"),
            new Player("Michał", "Adamczyk", 28, "M", "Łódź", "Ekspert", "Orły Poznania"),
            new Player("Jakub", "Szymczak", 25, "M", "Kraków", "Profesjonalista", "Orły Poznania"),
            new Player("Szymon", "Wysocki", 29, "M", "Gdańsk", "Ekspert", "Orły Poznania"),
            new Player("Bartłomiej", "Górski", 26, "M", "Szczecin", "Zaawansowany", "Orły Poznania"),
            new Player("Damian", "Kaczmarek", 27, "M", "Lublin", "Profesjonalista", "Orły Poznania"),
            new Manager("Andrzej", "Nowak", 40, "M", "Poznań", "Trener", "Orły Poznania", 60)
        ),
        new Team(
            "Smoki Łodzi",
            new[] {"Sponsor7", "Sponsor8"},
            "Łódź",
            new Player("Aleksandra", "Zielińska", 25, "F", "Łódź", "Profesjonalista", "Smoki Łodzi"),
            new Player("Natalia", "Kwiatkowska", 22, "F", "Poznań", "Zaawansowany", "Smoki Łodzi"),
            new Player("Monika", "Czerwińska", 27, "F", "Warszawa", "Ekspert", "Smoki Łodzi"),
            new Player("Ewa", "Sadowska", 23, "F", "Kraków", "Profesjonalista", "Smoki Łodzi"),
            new Player("Paulina", "Zawadzka", 30, "F", "Gdańsk", "Ekspert", "Smoki Łodzi"),
            new Player("Beata", "Jankowska", 24, "F", "Szczecin", "Zaawansowany", "Smoki Łodzi"),
            new Player("Alicja", "Kozłowska", 29, "F", "Lublin", "Profesjonalista", "Smoki Łodzi"),
            new Manager("Wojciech", "Lewandowski", 37, "M", "Łódź", "Trener", "Smoki Łodzi", 48)
        ),
        new Team(
            "Pantery Wrocławia",
            new[] {"Sponsor9", "Sponsor10"},
            "Wrocław",
            new Player("Karol", "Majewski", 26, "M", "Wrocław", "Profesjonalista", "Pantery Wrocławia"),
            new Player("Łukasz", "Ostrowski", 22, "M", "Poznań", "Zaawansowany", "Pantery Wrocławia"),
            new Player("Mateusz", "Sikorski", 27, "M", "Warszawa", "Ekspert", "Pantery Wrocławia"),
            new Player("Wojciech", "Michalski", 23, "M", "Kraków", "Profesjonalista", "Pantery Wrocławia"),
            new Player("Rafał", "Zając", 30, "M", "Gdańsk", "Ekspert", "Pantery Wrocławia"),
            new Player("Patryk", "Borkowski", 24, "M", "Szczecin", "Zaawansowany", "Pantery Wrocławia"),
            new Player("Sebastian", "Lis", 29, "M", "Lublin", "Profesjonalista", "Pantery Wrocławia"),
            new Manager("Mariusz", "Stępień", 41, "M", "Wrocław", "Trener", "Pantery Wrocławia", 36)
        ),
        new Team(
            "Żubry Białegostoku",
            new[] {"Sponsor11", "Sponsor12"},
            "Białystok",
            new Player("Marcin", "Krawczyk", 28, "M", "Białystok", "Profesjonalista", "Żubry Białegostoku"),
            new Player("Dariusz", "Zieliński", 23, "M", "Warszawa", "Zaawansowany", "Żubry Białegostoku"),
            new Player("Grzegorz", "Cieślak", 29, "M", "Kraków", "Ekspert", "Żubry Białegostoku"),
            new Player("Tomasz", "Baran", 26, "M", "Łódź", "Profesjonalista", "Żubry Białegostoku"),
            new Player("Piotr", "Urban", 31, "M", "Gdańsk", "Ekspert", "Żubry Białegostoku"),
            new Player("Andrzej", "Nowicki", 24, "M", "Szczecin", "Zaawansowany", "Żubry Białegostoku"),
            new Player("Kamil", "Sawicki", 28, "M", "Lublin", "Profesjonalista", "Żubry Białegostoku"),
            new Manager("Jarosław", "Nowakowski", 45, "M", "Białystok", "Trener", "Żubry Białegostoku", 60)
        ),
        new Team(
            "Orlęta Gdańska",
            new[] {"Sponsor13", "Sponsor14"},
            "Gdańsk",
            new Player("Maciej", "Sobczak", 27, "M", "Gdańsk", "Profesjonalista", "Orlęta Gdańska"),
            new Player("Krzysztof", "Malec", 24, "M", "Kraków", "Zaawansowany", "Orlęta Gdańska"),
            new Player("Bartłomiej", "Tomczyk", 29, "M", "Łódź", "Ekspert", "Orlęta Gdańska"),
            new Player("Konrad", "Czajka", 26, "M", "Warszawa", "Profesjonalista", "Orlęta Gdańska"),
            new Player("Adrian", "Kołodziej", 31, "M", "Poznań", "Ekspert", "Orlęta Gdańska"),
            new Player("Marek", "Grabowski", 23, "M", "Szczecin", "Zaawansowany", "Orlęta Gdańska"),
            new Player("Wiktor", "Borowski", 27, "M", "Lublin", "Profesjonalista", "Orlęta Gdańska"),
            new Manager("Zbigniew", "Jakubowski", 43, "M", "Gdańsk", "Trener", "Orlęta Gdańska", 50)
        ),
        new Team(
            "Jastrzębie Katowic",
            new[] {"Sponsor15", "Sponsor16"},
            "Katowice",
            new Player("Damian", "Wolski", 25, "M", "Katowice", "Profesjonalista", "Jastrzębie Katowic"),
            new Player("Szymon", "Janik", 23, "M", "Łódź", "Zaawansowany", "Jastrzębie Katowic"),
            new Player("Michał", "Pietrzak", 28, "M", "Warszawa", "Ekspert", "Jastrzębie Katowic"),
            new Player("Tadeusz", "Winiarski", 27, "M", "Kraków", "Profesjonalista", "Jastrzębie Katowic"),
            new Player("Igor", "Kulesza", 30, "M", "Gdańsk", "Ekspert", "Jastrzębie Katowic"),
            new Player("Hubert", "Czech", 24, "M", "Szczecin", "Zaawansowany", "Jastrzębie Katowic"),
            new Player("Tomasz", "Skiba", 29, "M", "Lublin", "Profesjonalista", "Jastrzębie Katowic"),
            new Manager("Przemysław", "Wróblewski", 39, "M", "Katowice", "Trener", "Jastrzębie Katowic", 48)
        ),
        new Team(
            "Rekiny Szczecina",
            new[] {"Sponsor17", "Sponsor18"},
            "Szczecin",
            new Player("Radosław", "Makowski", 25, "M", "Szczecin", "Profesjonalista", "Rekiny Szczecina"),
            new Player("Dominik", "Szymański", 22, "M", "Poznań", "Zaawansowany", "Rekiny Szczecina"),
            new Player("Eryk", "Lisowski", 27, "M", "Warszawa", "Ekspert", "Rekiny Szczecina"),
            new Player("Filip", "Kowal", 23, "M", "Kraków", "Profesjonalista", "Rekiny Szczecina"),
            new Player("Dawid", "Jasiński", 30, "M", "Gdańsk", "Ekspert", "Rekiny Szczecina"),
            new Player("Marek", "Gajewski", 24, "M", "Łódź", "Zaawansowany", "Rekiny Szczecina"),
            new Player("Michał", "Olejniczak", 29, "M", "Lublin", "Profesjonalista", "Rekiny Szczecina"),
            new Manager("Kamil", "Witkowski", 38, "M", "Szczecin", "Trener", "Rekiny Szczecina", 50)
        ),
        new Team(
            "Tygrysy Lublina",
            new[] {"Sponsor19", "Sponsor20"},
            "Lublin",
            new Player("Karolina", "Sobolewska", 26, "F", "Lublin", "Profesjonalista", "Tygrysy Lublina"),
            new Player("Natalia", "Głowacka", 23, "F", "Warszawa", "Zaawansowany", "Tygrysy Lublina"),
            new Player("Monika", "Krawczyk", 28, "F", "Kraków", "Ekspert", "Tygrysy Lublina"),
            new Player("Agnieszka", "Wilk", 24, "F", "Poznań", "Profesjonalista", "Tygrysy Lublina"),
            new Player("Joanna", "Krajewska", 30, "F", "Gdańsk", "Ekspert", "Tygrysy Lublina"),
            new Player("Ewa", "Wysoka", 25, "F", "Łódź", "Zaawansowany", "Tygrysy Lublina"),
            new Player("Zofia", "Czerny", 29, "F", "Szczecin", "Profesjonalista", "Tygrysy Lublina"),
            new Manager("Wojciech", "Kozioł", 41, "M", "Lublin", "Trener", "Tygrysy Lublina", 60)
        ),
        new Team(
            "Sokoły Radomia",
            new[] {"Sponsor21", "Sponsor22"},
            "Radom",
            new Player("Paweł", "Śliwiński", 24, "M", "Radom", "Profesjonalista", "Sokoły Radomia"),
            new Player("Marcin", "Zaręba", 23, "M", "Warszawa", "Zaawansowany", "Sokoły Radomia"),
            new Player("Krzysztof", "Leśniak", 27, "M", "Kraków", "Ekspert", "Sokoły Radomia"),
            new Player("Mateusz", "Raczyński", 26, "M", "Poznań", "Profesjonalista", "Sokoły Radomia"),
            new Player("Bartosz", "Łuczak", 30, "M", "Gdańsk", "Ekspert", "Sokoły Radomia"),
            new Player("Jakub", "Wilczyński", 25, "M", "Łódź", "Zaawansowany", "Sokoły Radomia"),
            new Player("Adam", "Drabik", 29, "M", "Lublin", "Profesjonalista", "Sokoły Radomia"),
            new Manager("Jarosław", "Sroka", 39, "M", "Radom", "Trener", "Sokoły Radomia", 54)
        ),
        new Team(
            "Niedźwiedzie Torunia",
            new[] {"Sponsor23", "Sponsor24"},
            "Toruń",
            new Player("Tomasz", "Kubicki", 26, "M", "Toruń", "Profesjonalista", "Niedźwiedzie Torunia"),
            new Player("Grzegorz", "Dębski", 22, "M", "Warszawa", "Zaawansowany", "Niedźwiedzie Torunia"),
            new Player("Mariusz", "Olech", 28, "M", "Kraków", "Ekspert", "Niedźwiedzie Torunia"),
            new Player("Rafał", "Kościelny", 23, "M", "Poznań", "Profesjonalista", "Niedźwiedzie Torunia"),
            new Player("Damian", "Kulesza", 30, "M", "Gdańsk", "Ekspert", "Niedźwiedzie Torunia"),
            new Player("Piotr", "Żuk", 25, "M", "Łódź", "Zaawansowany", "Niedźwiedzie Torunia"),
            new Player("Marek", "Florek", 29, "M", "Szczecin", "Profesjonalista", "Niedźwiedzie Torunia"),
            new Manager("Andrzej", "Borecki", 42, "M", "Toruń", "Trener", "Niedźwiedzie Torunia", 48)
        )
    };

    private List<Team> _reserveTeams = new List<Team>
    {
        new Team(
        "Wilki Bydgoszczy",
        new[] {"Sponsor25", "Sponsor26"},
        "Bydgoszcz",
        new Player("Maciej", "Grabowski", 24, "M", "Bydgoszcz", "Profesjonalista", "Wilki Bydgoszczy"),
        new Player("Tomasz", "Zawadzki", 23, "M", "Toruń", "Zaawansowany", "Wilki Bydgoszczy"),
        new Player("Karol", "Błaszczyk", 28, "M", "Gdańsk", "Ekspert", "Wilki Bydgoszczy"),
        new Player("Michał", "Kołodziej", 25, "M", "Poznań", "Profesjonalista", "Wilki Bydgoszczy"),
        new Player("Damian", "Król", 30, "M", "Łódź", "Ekspert", "Wilki Bydgoszczy"),
        new Player("Sebastian", "Żukowski", 26, "M", "Warszawa", "Zaawansowany", "Wilki Bydgoszczy"),
        new Player("Rafał", "Kozioł", 27, "M", "Kraków", "Profesjonalista", "Wilki Bydgoszczy"),
        new Manager("Andrzej", "Lewicki", 40, "M", "Bydgoszcz", "Trener", "Wilki Bydgoszczy", 48)
        ),
        new Team(
            "Orły Łodzi",
            new[] {"Sponsor27", "Sponsor28"},
            "Łódź",
            new Player("Grzegorz", "Piątek", 26, "M", "Łódź", "Profesjonalista", "Orły Łodzi"),
            new Player("Mariusz", "Górka", 22, "M", "Szczecin", "Zaawansowany", "Orły Łodzi"),
            new Player("Krzysztof", "Sosnowski", 28, "M", "Warszawa", "Ekspert", "Orły Łodzi"),
            new Player("Radosław", "Lisowski", 23, "M", "Gdańsk", "Profesjonalista", "Orły Łodzi"),
            new Player("Paweł", "Jabłoński", 29, "M", "Poznań", "Ekspert", "Orły Łodzi"),
            new Player("Łukasz", "Borkowski", 25, "M", "Kraków", "Zaawansowany", "Orły Łodzi"),
            new Player("Adrian", "Kamiński", 27, "M", "Lublin", "Profesjonalista", "Orły Łodzi"),
            new Manager("Zbigniew", "Kowal", 42, "M", "Łódź", "Trener", "Orły Łodzi", 54)
        ),
        new Team(
            "Rekiny Poznania",
            new[] {"Sponsor29", "Sponsor30"},
            "Poznań",
            new Player("Adam", "Czerwiński", 24, "M", "Poznań", "Profesjonalista", "Rekiny Poznania"),
            new Player("Piotr", "Szymczak", 23, "M", "Łódź", "Zaawansowany", "Rekiny Poznania"),
            new Player("Bartłomiej", "Urban", 28, "M", "Warszawa", "Ekspert", "Rekiny Poznania"),
            new Player("Konrad", "Kołodziej", 26, "M", "Kraków", "Profesjonalista", "Rekiny Poznania"),
            new Player("Dawid", "Nowakowski", 31, "M", "Gdańsk", "Ekspert", "Rekiny Poznania"),
            new Player("Eryk", "Sikora", 24, "M", "Toruń", "Zaawansowany", "Rekiny Poznania"),
            new Player("Maciej", "Flis", 27, "M", "Lublin", "Profesjonalista", "Rekiny Poznania"),
            new Manager("Rafał", "Kurek", 39, "M", "Poznań", "Trener", "Rekiny Poznania", 52)
        ),
        new Team(
            "Smoki Warszawy",
            new[] {"Sponsor31", "Sponsor32"},
            "Warszawa",
            new Player("Tomasz", "Malinowski", 25, "M", "Warszawa", "Profesjonalista", "Smoki Warszawy"),
            new Player("Jan", "Lewandowski", 22, "M", "Poznań", "Zaawansowany", "Smoki Warszawy"),
            new Player("Sebastian", "Adamski", 27, "M", "Łódź", "Ekspert", "Smoki Warszawy"),
            new Player("Radosław", "Wójcik", 24, "M", "Kraków", "Profesjonalista", "Smoki Warszawy"),
            new Player("Łukasz", "Zieliński", 30, "M", "Gdańsk", "Ekspert", "Smoki Warszawy"),
            new Player("Karol", "Mazur", 26, "M", "Toruń", "Zaawansowany", "Smoki Warszawy"),
            new Player("Paweł", "Stankiewicz", 29, "M", "Lublin", "Profesjonalista", "Smoki Warszawy"),
            new Manager("Wojciech", "Rybak", 43, "M", "Warszawa", "Trener", "Smoki Warszawy", 60)
        )
    };

    public List<Team> Teams
    {
        get => _teams;
        set => _teams.AddRange(value);
    }

    public List<Team> ReserveTeams
    {
        get => _reserveTeams;
        set => _reserveTeams.AddRange(value);
    }

}