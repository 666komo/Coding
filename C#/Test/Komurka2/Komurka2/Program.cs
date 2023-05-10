//  TEST - Komůrka IT2B sk1 25.4.2023

// Uživatel zadá počet čísel. Vygenerujte náhodné hodnoty z intervalu < 4,140 > a vypočítejte průměr.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Komurka2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Title = "Vypocet prumeru z nahodnych cisel";
            int a,i,poc=0,soucet=0;
            double prum = 0;
            Random rand = new Random();
            WriteLine("Zadej počet čísel");
            if (!int.TryParse(ReadLine(), out a)) WriteLine("Nebylo zadáno číslo");
            else
            {
                for (i = 1; i <= a; i++)
                {
                    int num = rand.Next(4,140);
                    soucet = num + soucet;
                    poc = poc + 1;
                    Write(num + ", ");
                }
                prum = soucet / poc;
                WriteLine("Pruměr čisel je " + prum);
            }
            ReadKey();
        }
    }
}
