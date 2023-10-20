using System;
using static System.Console;

class Prg
{
    static void Main()
    {
        // Zjisteni poctu znaku ve slove
        Write("Napis slovo: ");
        string word = ReadLine(); 
        int delkas = word.Length; //Ziskani delky slova do integerovske promenne
        WriteLine($"Pocet znaku: {delkas}"); 
        
        // Vypis slova pozpatku na radek a pod sebe
        char[] charpole = word.ToCharArray(); // Prevod ze stringoveho slova do charoveho pole
        Array.Reverse(charpole); // Obraceni poradi pismen slova v poli
        foreach(char znak in charpole) // Vypis na radek
        {
            Write(znak);
        }
        WriteLine();
        foreach(char znak in charpole) // Vypis pod sebe
        {
            WriteLine(znak);
        }
        ReadKey();

        Clear();
        
        // Zjisteni poctu znaku a slov ve vete a zda je veta tazaci, oznamovaci nebo rozkazovaci
        Write("Napis vetu: "); 
        string veta = ReadLine(); // Nacteni slova do pameti ve stringove promenne
        int pocetz = 0;
        int pocets = 0;
        bool iw = false;
        int pocetzsmai = veta.Length; // (Pocet znaku s mezerami a interpunkci)
        
        foreach (char p in veta) // Prelozeno: Pro kazdy znak v prommene string
        {
            if (char.IsLetter(p)) // Jestli je znak pismeno
            {
                    pocetz++;  // Pricti 1 k integerovske promenne pocetz (pocet znaku)
                    iw = true; // Nachazi se ve slove (iw: in word/ ve slove)
            }
            else if(iw) // Jestli je konec slova
            {
                pocets++; // Pricti 1 k promenne pocets (pocet slov)
                iw = false; // Nenachazi se ve slove
            }
        }
        if (iw) // Kontrola, jestli posledni znak je soucast slova 
        {
            pocets++; 
        }
        
        // Vypis zjistenych hodnot
        WriteLine($"Pocet znaku: {pocetz}");
        WriteLine($"Pocet znaku s mezerami a interpunkci: {pocetzsmai}");
        WriteLine($"Pocet slov: {pocets}");
            
        string typvety = "Neurceno"; // Zjisteni typu vety podle toho, na co konci

        if (veta.EndsWith("?"))
        {
            typvety = "tazaci";
        }
        else if (veta.EndsWith("!"))
        {
            typvety = "rozkazovaci";
        }
        else if (veta.EndsWith("."))
        {
            typvety = "oznamovaci";
        }
        
        WriteLine($"Veta je {typvety}"); //Vypis
        ReadKey();
    }
}