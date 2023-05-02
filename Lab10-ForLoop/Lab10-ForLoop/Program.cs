// Write a program that calculates the average of numbers given by the user.

using System;

namespace Lab10_ForLoop
{
    internal class Program
    {
        static void Main()
        {
            float sum = 0.0f;
            float average;
            string input;
            int totalNumbers = 10;

            // sequentially add the numbers up from 1 to totalNumbers
            for (int i = 1; i <= totalNumbers; i++)
            {
                Console.Write("Insert number {0} of 10 to sum: ", i);
                input = Console.ReadLine();
                sum += float.Parse(input);
            }

            // finding the average
            average = sum / totalNumbers;
            Console.WriteLine("The average of the given {1} numbers is {0}", average, totalNumbers);
            Console.ReadLine();
        }
    }
}
