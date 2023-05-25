using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Had   - nastavení obdélníkového hracího pole - okraj z nějakého znaku
 *      - nastavení obsazenosti jednotlivých hracích políček uvnitř hrací plochy
 *      - umístění jídla - jablka - náhodná pozice, v programu je generování nového jablka, pokud had sežere první
 *      - hráč získá 1 bod za sežrání jablka
 *      - hodnocení šikovnosti hráče - vyrobí nejdelšího hada - nenarazí do zdi ani do svého těla
 *Doporučení - ručně zvětšit dialogové okno po spuštění hry
 */
namespace had_console
{   
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(45, 30);
            Console.WriteLine("Hra HAD, ovládá se šipkami");

 

            //hrací plocha - vykreslení okrajů
            for (int i = 1; i < 31; i++)
                Console.Write("#");
            for (int i = 1; i < 31; i++)
               Console.WriteLine("a");
            for (int i = 1; i < 31; i++)
                Console.Write("0");
            
            Console.SetCursorPosition(30,2);

 

            for (int i = 0; i < 31; i++)
            {
                Console.WriteLine("#");
                Console.SetCursorPosition(30, 2 + i);
            } // hrací plocha vykreslená

 

            //nastavení stavu políček herní plochy - dvourozměrné pole
            int [,]stav = new int [30,30];  //do prázdné místnosti donesu židle - do třiceti řad po třiceti židlích

 

            for (int i = 1; i < 30; i++)
                for (int j = 2; j < 30; j++)
                { stav[i, j] = 2; }  //2 = hrací políčko je prázdné - všechny židle jsou prázdné (stav = 2)
            
            //jablko
                //int ja=10, jb=15;
           
               //  náhodná pozice jablka
              Random pozice= new Random();
              int ja = pozice.Next(1,29);  //náhodné číslo od 1 do 28
              int jb = pozice.Next(2,29);
              
              Console.SetCursorPosition(ja, jb);
              Console.Write("j");

 

            //body - za každou novou část těla had získá bod
            int body=0;
            int delka_hada = 1;
            
            //had
            int prek = 0;       //typ překážky - 0=žádná, 5=zeď, 6=jablko
      
            int a = 1, b = 2;   //původní souřadnice hlavy hada  [a,b]
           
            Console.SetCursorPosition(a, b);
            Console.Write("@"); //zavináč je hlava hada
            stav[a, b] = 1;     //na židli v b té řádě a a tém sloupci sedí hlava hada

 

            do
            {
                //kontrola směru pohybu
                
                ConsoleKeyInfo smer = Console.ReadKey(true); //něco uživatel stiskne, ale neukáže se to na monitoru
                switch (smer.Key)
                {                       //po stisku šipky se změní příslušná souřadnice - dolů = řádek + 1 tedy b++
                    case ConsoleKey.DownArrow: b++;  break;
                    case ConsoleKey.UpArrow: b--;  break;
                    case ConsoleKey.LeftArrow: a--;  break;
                    case ConsoleKey.RightArrow: a++;  break;
                }

 

               
                //má se pohnout? a, b jsou nové souřadnice
                
                if (a == 0 || b == 1 || a == 30 || b == 31||stav[a, b] == 1) //zkontroluje, zda na dané souřadnici něco není
                { prek = 5; }   //na dané pozici je zeď nebo vlastní tělo - překážka, hodnota překážky 5 znamená, že neproleze
                if (a == ja && b == jb) { prek = 6; body++; } //našel jablko, do prek uloží šťastné číslo 6 a přidá si bod

 

                //hni sebou
                 
                 if (prek != 5) //když nemá v cestě překážku, tak na novou pozici zapíše novou hlavu
                 {
                     Console.SetCursorPosition(a, b);   //nastav kurzor na nové souřadnice
                     stav[a, b] = 1;                    //obsadím židličku hadem
                     Console.Write("@");                //nová hlava hada
                     delka_hada++;      //přidá 1 do délky hada
                 }

 

                 if (prek == 6) //staré jablko sežráno, vyrobí nové jablko
                 {
                     prek = 0;
                     do
                     {
                         ja = pozice.Next(1, 29);  //náhodné číslo od 1 do 28 - aby nebylo jablko ve zdi
                         jb = pozice.Next(2, 29);
                     }
                     while (stav[ja, jb] == 1);     //aby nebylo jablko v těle hada

 

                     Console.SetCursorPosition(ja, jb);
                     Console.Write("j");
                 }

 

            }
            while (prek != 5);      //opakuje, dokud nenarazí na překážku nebo sám na sebe

 

                    //pokud z celého programu vyhodím stav[] - had proleze vlastním tělem bez potíží a pokračuje dál, nové jablko může vzniknout v těle hada

 


            Console.SetCursorPosition(0, 32);       //pod hrací pole napíše počet bodů za sežraná jablka
            Console.WriteLine("Sežráno jablek = "+body);      //a pak vypíše celkovou délku vytvořeného hada
            Console.WriteLine("Délka hada = " + delka_hada);
           
            
            Console.ReadKey();

 

 

 


        }
    }
}
