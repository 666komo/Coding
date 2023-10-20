// Komůrka IT2B
// Napište program, který zjistí, zda je dané číslo záporné.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace du2_Komurka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a;
            WriteLine("Zadej jakékoliv číslo");
            if (!int.TryParse(ReadLine(), out a)) WriteLine("Nebylo zádáno číslo.\nUkončuji...");
            else
            {
                if (a < 0) WriteLine("Číslo je záporné");
                else if (a == 0) WriteLine("Číslo je rovno nule");
                else WriteLine("Číslo je kladné");
            }

            ReadKey();
            
        }
    }
}
