using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.Yellow ^ ConsoleColor.Red;
            Title = "Obvod a obsah obdélníku";
            Clear();
            WriteLine("hokus pokus raz dva tři");
            WriteLine("Zadej délku jedné strany");
            int a = Convert.ToInt32(Console.ReadLine());
            WriteLine("Zadej délku druhé strany");
            int b = Convert.ToInt32(Console.ReadLine());
            int obvod = (a + b) * 2;
            int obsah = a * b;
            Clear();
            WriteLine("Obvod je " + obvod + ". \nObsah je " + obsah+".");
            ReadKey();
        }
    }
}
