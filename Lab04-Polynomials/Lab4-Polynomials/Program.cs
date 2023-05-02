using System;

class Program
{
    static void Main()
    {
        // Ask for an input 
        Console.Write("Please enter an integer value for x: ");

        // Read the input and save it into a String Type
        string input;
        input = Console.ReadLine();

        // Convert the String Type into an Integer Type
        int x;  // convert a string into an integer type

        x = int.Parse(input);

        // Calculate the Polynomial (3x^3-5x^2+6) and save it into an Integer Type
        //int result;
        //result = (3 * (x * x * x)) - (5 * (x * x)) + 6;
        int result = (int)((3 * x * x * x) - (5 * x * x) + 6);

        // Show the result on the Console (on the screen)
        Console.WriteLine("The calculated value for 3x^3-5x^2+6 is {0}", result);

        // Hold the Console so we can see the result
        Console.ReadLine();
    }
}

/*
Output:

Please enter an integer value for x: 2
The calculated value for 3x^3-5x^2+6 is 10
*/
