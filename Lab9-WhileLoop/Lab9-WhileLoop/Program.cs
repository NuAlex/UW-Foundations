using System;

namespace Lab9_WhileLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            while (sum < 100)
            {
                Console.Write("Enter a number:");
                string input = Console.ReadLine();

                int number = int.Parse(input);
                sum += number;

                Console.WriteLine("Current sum is {0}\n", sum);
            }

            Console.WriteLine("Done! Your sum is greater than 100. \nPress any key to exit.", sum);
            Console.ReadLine();
        }
    }
}
