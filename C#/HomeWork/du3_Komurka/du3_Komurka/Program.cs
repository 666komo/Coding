// Komůrka IT2B
// Úkol č. 33 - Napište program, který vypíše všechny dělitele daného přirozeného čísla a jejich celkový počet.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace du3_Komurka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, i;
            Title = "Program na zjištění všech dělitelů daného čísla";
            WriteLine("Zadej číslo");
            if (!int.TryParse(ReadLine(), out a)) WriteLine("Nebylo zadáno číslo");
            else
            {
                Clear();
                WriteLine("Čísla, kterými je číslo "+a+" dělitelné: ");
                for(i=1;i<=a;i++)
                {
                    if (a % i == 0) Write(i+", ");
                }
            }
            Write("\n\n");
            WriteLine("Zmáčkněte náhodné tlačítko pro ukončení...");
            ReadKey();
        }
    }
}
