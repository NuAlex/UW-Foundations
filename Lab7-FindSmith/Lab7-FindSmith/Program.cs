// Hint: Use the string EndsWith method.

using System;

namespace Lab7_FindSmith
{
    internal class Program
    {
        static void Main()
        {
            string str;
            do
            {
                Console.Write("Enter a person's full name: ");
                str = Console.ReadLine();
                str = str.ToLower();

                if (str.EndsWith(" smith"))
                {
                    Console.WriteLine("You found a 'Smith' in '{0}'!", str);
                }
                else
                {
                    Console.WriteLine("'Smith' not found in '{0}'. Please try again.", str);
                }

                Console.WriteLine("\nPress CTRL+C to exit.\n");
            } while (true);
        }
    }
}
