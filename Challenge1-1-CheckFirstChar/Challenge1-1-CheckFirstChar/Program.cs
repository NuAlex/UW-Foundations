using System;

namespace Challenge1_1_CheckFirstChar
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // ---- Write a program that determines if the first character typed in is alphabetic
            char aChar = (char) 65;
            int iChar = aChar;
            Console.WriteLine("EXAMPLE: '{1}' is a char #{0} and is alfanumeric (upper-case letter).\n\n", iChar, aChar);
            
            char keyChar;
            do
            {
                Console.WriteLine("Press any key to try other characters or press 'X' to exit:");
                ConsoleKeyInfo keyPress = Console.ReadKey(true);
                keyChar = keyPress.KeyChar;
                string alphanumeric;

                if ((int)keyChar > 47 && (int)keyChar <58)
                {
                    alphanumeric = "alfanumeric (number)";
                }
                else if ((int)keyChar > 64 && (int)keyChar < 91)
                {
                    alphanumeric = "alfanumeric (upper-case letter)";
                }
                else if ((int)keyChar > 96 && (int)keyChar < 123)
                {
                    alphanumeric = "alfanumeric (lower-case letter)";
                }
                else
                {
                    alphanumeric = "not alfanumeric";
                }

                Console.WriteLine("'{0}' is a char #{1} and is {2}.", keyChar, (int)keyChar, alphanumeric);
                Console.WriteLine();

            } 
            while (keyChar != ((char) 'X') && keyChar != ((char)'x'));

            Console.WriteLine("Press ENTER to close.");
            Console.ReadLine();
        }
    }
}
