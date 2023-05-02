using System;

namespace Lab5_FindASCIIvalues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a character:");

            // Let the user enter a string and press enter.
            string input = Console.ReadLine();

            // Grab the first character of the string (str[0])
            char someChar = (char)input[0];

            // Convert the character to an integer to get the ascii value
            int charValue = (int)someChar;

            Console.WriteLine("ASCII value is: {0}", charValue);
            Console.ReadLine();
        }
    }
}
