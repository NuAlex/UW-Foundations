using System;

class Program
{
    static void Main()
    {
        // Declare a variable named "age" of type "int"
        int age;

        // Set the value of "age" to 21
        age = 21; // --> commenting this will cause an "unassigned local variable" error since the var does not have a value assigned.

        Console.WriteLine("My age is {0}", age);

        // increment age by 2
        age += 2;

        Console.WriteLine("My real age is {0}", age);
        Console.ReadLine();
    }
}