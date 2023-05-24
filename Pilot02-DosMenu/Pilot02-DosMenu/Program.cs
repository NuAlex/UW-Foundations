using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot02_DosMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("White on blue.");
            Console.WriteLine("Another line.");
            Console.ResetColor();

            Console.ReadLine();
        }
    }
}
