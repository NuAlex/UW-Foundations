using System;


namespace Lab12a_ForEachLoop2
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                int[] numbers = new int[] { 10, 15, 20, 25, 30, 35 };

                Console.Write("Enter a number:");
                string str = Console.ReadLine();

                int input = int.Parse(str);
                bool found = false;

                // use for to look for the number
                foreach (int x in numbers)
                {
                    if (x == input)
                    { 
                        found = true; 
                        break; 
                    }
                }

                if (found) // if true, i.e. found the number, say Found the Number
                {
                    Console.WriteLine("Found the number!");
                }
                else // if not true, did not find it, say Did not Find the Number
                {
                    Console.WriteLine("Sorry, did not find the number");
                }

                Console.ReadLine(); // Pause to see the results
            }
        }
    }
}
