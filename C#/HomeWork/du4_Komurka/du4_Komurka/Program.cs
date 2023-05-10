// Komůrka IT2B

// Vytvořte hrací pole s odlišnými znaky na krajích a umístěte kurzor doprostřed pole

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace du4_Komurka
{
    internal class Program
    {
        static void Main()
        {
            Title = "Hrací pole";
            int w = 30, h = 15,i,ii;
            int wc=15,hc=5;
            SetCursorPosition(wc, hc);

            for (i = 0; i <= w + 2; i++) { Write("#"); }
            WriteLine("");

            for (i = 0; i <= h; i++)
            {
                hc = hc + 1;
                SetCursorPosition(wc, hc);
                Write("&");

                for (ii = 0; ii <= w; ii++)
                {
                    Write(" ");
                }
                WriteLine("@");
            }
            SetCursorPosition(wc, 22);
            for (i = 0; i <= w + 2; i++)
            {
                Write("$");
            }
            SetCursorPosition(31, 14);
            ReadKey();
        }
    }
}
