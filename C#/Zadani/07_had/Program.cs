// Komůrka IT2B
// Had

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace _07_Had
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rozmerpole;
            // Menu
            int rad = 0;
            int slo = 0;
            Console.WriteLine("*************************************");
            Console.WriteLine(" _   _           _\n| | | | __ _  __| |\n| |_| |/ _` |/ _` |\n|  _  | (_| | (_| |\n|_| |_|\\__,_|\\__,_|");
            Console.WriteLine("\n*************************************");
            Console.Write("\nVyber velikost hracího pole:\n1. Malé\n2. Střední\n3. Velké\n\n Volba - ");
            // Velikost pole
            if (!int.TryParse(Console.ReadLine(), out rozmerpole))
            {
                Console.Write("Neplatný rozměr pole\nUkončuji...\n");
                Console.ReadKey();
            }
            else
            {
                switch (rozmerpole)
                {
                    case 1: rad = 10; slo = 15; break;
                    case 2: rad = 15; slo = 20; break;
                    case 3: rad = 20; slo = 25; break;
                }
            }

            //Nast. pole
            int[,] pole = new int[rad, slo];
            for (int i = 0; i < rad; i++)
            {
                for (int j = 0; j < slo; j++)
                {
                    if (i == 0 || i == rad - 1 || j == 0 || j == slo - 1)
                    {
                        pole[i, j] = 1;
                    }
                }
            }
            // Had
            int hadr = rad / 2;
            int hads = slo / 2;
            pole[hadr, hads] = 2;



            // Jablka
            Random rand = new Random();
            int jabrandr = rand.Next(1, rad - 1);
            int jabrands = rand.Next(1, slo - 1);
            pole[jabrandr, jabrands] = 3;

            // Konf.
            Console.Title = "Had";
            int hpr = 0;
            int hps = 0;
            while (true)
            {
                hadr += hps;
                hads += hpr;

                // Oveření, zda se had nenarazil na hranici pole
                if (hadr <= 0 || hadr >= rad-1||hads<=0||hads >= slo - 1)
                {
                    Console.Clear();
                    Console.Write(" _  __                       _   _\n");
                    Console.Write("| |/ /___  _ __   ___  ___  | | | |_ __ _   _\n");
                    Console.Write("| ' // _ \\| '_ \\ / _ \\/ __| | |_| | '__| | | |\n");
                    Console.Write("| . \\ (_) | | | |  __/ (__  |  _  | |  | |_| |\n");
                    Console.Write("|_|\\_\\___/|_| |_|\\___|\\___| |_| |_|_|   \\__, |\n");
                    Console.Write("                                        |___/\n\n");
                    Console.WriteLine("Stiskni libovolnou klávesu pro ukončení hry");
                    Console.ReadKey();
                    break;
                }

                // Ověření, zda had snědl jablko
                if (pole[hadr, hads] == 3)
                {
                    jabrandr = rand.Next(1, rad - 1);
                    jabrands = rand.Next(1, rad - 1);
                    pole[jabrandr, jabrands] = 3;
		    
                }

                // Pohyb hada
                pole[hadr, hads] = 2;
                pole[hadr - hps, hads - hpr] = 0;
		
                // Výstup
                Console.Clear();
                for (int i = 0; i < rad; i++)
                {
                    for (int j = 0; j < slo; j++)
                    {
                        if (pole[i, j] == 1)
                        {
                            Console.Write("1 ");
                        }
                        else if (pole[i, j] == 2)
                        {
                            Console.Write("▄ ");
                        }
                        else if (pole[i, j] == 3)
                        {
                            Console.Write("@ ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                    Console.WriteLine();
                }
                //System.Threading.Thread.Sleep(1000);
		
		// Ovládání
        	ConsoleKeyInfo keyInfo = Console.ReadKey();	 
                switch (keyInfo.Key)
                	{
                	    case ConsoleKey.UpArrow:
                	        hps = -1;
                	        hpr = 0;
                	        break;
                	    case ConsoleKey.DownArrow:
                	        hps = 1;
                	        hpr = 0;
                	        break;
                	    case ConsoleKey.LeftArrow:
                	        hps = 0;
                	        hpr = -1;
                	        break;
                	    case ConsoleKey.RightArrow:
                	        hps = 0;
                	        hpr = 1;
                	        break;
                	}
	 	 
		
              
            }

        }

    }

}
