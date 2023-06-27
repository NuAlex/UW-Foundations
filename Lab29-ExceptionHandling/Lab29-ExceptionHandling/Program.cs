using System;

class Program
{
    static void Main()
    {
        do
        {
            Console.Write("Check Number: ");
            string checkNumber = Console.ReadLine();
            try
            {
                Console.WriteLine("You entered check #{0}", int.Parse(checkNumber));
            }
            catch
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
        while (true);
    }
}