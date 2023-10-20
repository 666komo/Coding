using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace _05_ahojmiso
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Napis slovo: ");
            string word = ReadLine();

            int delkas = word.Length;

            WriteLine($"Pocet znaku: {delkas}");
            ReadKey();
            char[] charpole = word.ToCharArray();
            Array.Reverse(charpole);
            foreach(char znak in charpole)
            {
                Write(znak);
            }
            WriteLine();
            foreach(char znak in charpole)
            {
                WriteLine(znak);
            }
            ReadKey();

            Clear();

            Write("Napis vetu: ");
            string veta = ReadLine();
            int pocetz = 0;
            int pocets = 0;
            bool iw = false;

            foreach(char p in veta)
            {
                if (char.IsWhiteSpace(p))
                {
                    if (iw)
                    {
                        pocets++;
                        iw = false;
                    }
                }
                else
                {
                    pocetz++;
                    iw = true;
                }
            }
            if (iw)
            {
                pocets++;
            }

            WriteLine($"Pocet znaku: {pocetz}");
            WriteLine($"Pocet slov: {pocets}");

	    string typvety = "Neurceno";

            ReadKey();
        }
    }
}
