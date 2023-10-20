using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _06_nahoda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int a,b=0,i;
            WriteLine("Zadej pocet ctvercu");
            if (!int.TryParse(ReadLine(), out a)) WriteLine("Nebylo zadáno číslo.");
            else
            {
                for (i = 1; i <= a; i++) 
                {
                    int randnum = r.Next(0, 100);
                    b = b + 1;
                    WriteLine(b + ". čtverec má délku strany " + randnum + "cm");
                }
            }
            ReadKey();
        }
    }
}
