/*
Lab: ref and out (10 mins)

Write a Swap method to swap to integer values. This is a very common programming technique.

Here x is set to 11 and y is set to 22.

When the Swap method is called x will be 22 and y will be 11.
*/

using System;

namespace Lab17_RefAndOut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = 11;
            var y = 22;

            Swap(ref x, ref y);

            Console.WriteLine("X={0} should be 22", x);
            Console.WriteLine("Y={0} should be 11", y);
            Console.ReadLine();

        }

        // Write the Swap method so that
        // the two values passed in are swapped.
        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}
