using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komurka
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej váhu jablek");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Zadej váhu hroznů");
            float b = float.Parse(Console.ReadLine());
            Console.Clear();
            double c, d, e, f;

            c = b * 0.85;
            d = a * 0.60;
            e = a + b;
            f = c + d;
            Console.WriteLine("Dohromady se přivezlo " + e + "kg ovoce.");
            Console.WriteLine("Původní váha jablek byla " + a + "kg a vzniklo tak " + d + " litrů jablek.");
            Console.WriteLine("Původní váha hroznů byla " + b + "kg a vzniklo tak " + c + " litrů jablek.");
            Console.WriteLine("Dohromady moštárna vytvořila " + f + " litrů šťávy");
            
        }
    }
}
