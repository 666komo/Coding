using System;

class Program
{
    // Metoda pro sčítání: žádný vstup s výstupní hodnotou
    static int Scitani()
    {
        int cislo1 = 10;
        int cislo2 = 20;
        int vysledek = cislo1 + cislo2;
        return vysledek;
    }

    // Metoda pro odčítání: žádný vstup bez výstupní hodnoty
    static void Odcitani()
    {
        int cislo1 = 50;
        int cislo2 = 30;
        int vysledek = cislo1 - cislo2;
        Console.WriteLine("Výsledek odčítání je: " + vysledek);
    }

    // Metoda pro násobení: se vstupem s výstupní hodnotou
    static int Nasobeni(int cislo1, int cislo2)
    {
        int vysledek = cislo1 * cislo2;
        return vysledek;
    }

    // Metoda pro dělení: bez vstupu bez výstupní hodnoty
    static void Deleni()
    {
        int cislo1 = 100;
        int cislo2 = 5;
        int vysledek = cislo1 / cislo2;
        Console.WriteLine("Výsledek dělení je: " + vysledek);
    }

    static void Main(string[] args)
    {
        // Volání metody pro sčítání
        int suma = Scitani();
        Console.WriteLine("Součet je: " + suma);

        // Volání metody pro odčítání
        Odcitani();

        // Volání metody pro násobení s vstupy 8 a 4
        int produkt = Nasobeni(8, 4);
        Console.WriteLine("Výsledek násobení je: " + produkt);

        // Volání metody pro dělení
        Deleni();
    }
}