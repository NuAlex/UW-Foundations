// Lab 12 - ForEachLoops
// Create an array of numbers and find the max and min values of your array

using System;

namespace Lab12_ForEachLoop
{
    internal class Program
    {
        static void Main()
        {
            // start with the given array
            int[] numbers = new int[] { 0, 2, 5, 100, -1, 4, 8, -5 };

            // define the max and min
            int min = 0;
            int max = 0;

            foreach (int x in numbers)
            {
                if (min > x)
                {
                    // code to find the min
                    min = x;
                }
                if (max < x)
                {
                    // code to find the max
                    max = x;
                }
            }

            Console.WriteLine("The Minimum value is {0}", min);
            Console.WriteLine("The Maximum value is {0}", max);

            Console.ReadLine();

        }
    }
}
