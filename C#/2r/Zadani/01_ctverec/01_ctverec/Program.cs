using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _01_ctverec
{
    class Program
    {
        static void Main(string[] args)
        {
            int b,i;
            do
            {
                WriteLine("Jdu ti vypocitat obvod a obsah ctverce lol");
                WriteLine("------------------------------------------");
                WriteLine("Zadej pocet ctvercu - ");
                int pocet = int.Parse(ReadLine());
                for (i = 1; i <= pocet; i++)
                {
                    WriteLine("");
                    WriteLine("Zadej delku strany");
                    float a = float.Parse(ReadLine());
                    if (a <= 0)
                    {
                        WriteLine("Zadána neplatná hodnota");
                    }
                    else
                    {
                        float obvod = a * 4;
                        float obsah = a * a;
                        WriteLine("Obvod je - " + obvod + "\tObsah je - " + obsah);
                        WriteLine("");
                    }
                }
                WriteLine("Chces znovu spustit program?");
                WriteLine("1.\tAno");
                WriteLine("2.\tNe");
                b = int.Parse(ReadLine());
            }
            
            while (b == 1);
        }
    }
}
