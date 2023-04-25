using System;

namespace Challenge1_1_CheckFirstChar
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char aChar = (char) 65;
            int iChar = aChar;
            Console.WriteLine("'{1}' is a char #{0}.\n\n", iChar, aChar);
            
            char keyChar;
            do
            {
                Console.WriteLine("Press any key to try other characters or press 'X' to exit:");
                ConsoleKeyInfo keyPress = Console.ReadKey(true);
                keyChar = keyPress.KeyChar;
                Console.WriteLine("'{0}' is a char #{1}.", keyChar, (int)keyChar);
                Console.WriteLine();

            } 
            while (keyChar != ((char) 'X') && keyChar != ((char)'x'));

            Console.WriteLine("Press ENTER to close.");
            Console.ReadLine();
        }
    }
}
