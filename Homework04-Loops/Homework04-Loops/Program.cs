/* 
 * Homework #4 - Loops
 * 
 * Write a program that calculates factorial of an integer n given by the user. 
 * 
 * Please enter a small integer: 5
 * 5! = 120
 * 
 * A factorial is calculated as follows:
 * f(5) = 5 * 4 * 3 * 2 * 1
 * 
 */

using System;

namespace Homework04_Loops
{
    internal class Program
    {
        static void Main()
        {
            int input;
            double result;

            do
            {
                Console.Write("Factorial calculation - Please enter a small integer: ");
                int.TryParse(Console.ReadLine(), out input);
                result = 1;

                for (int i = input; i > 0; i--)
                {
                    result = result * i;
                }

                Console.WriteLine("Factorial of '{0}' is: {1}", input, result);
                Console.WriteLine("\nPress CRTL+C to exit.\n");
            }
            while (true);
        }
    }
}
