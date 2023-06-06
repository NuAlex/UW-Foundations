//Add a static Print function that takes a string title and int[] array.
using System;

class Sorter
{
    public static void BubbleSort(int[] array)
    {
        for (int index = 0; index < array.Length; index++)
        {
            for (int inner = index; inner < array.Length; inner++)
            {
                if (array[index] > array[inner])
                {
                    Swap(ref array[index], ref array[inner]);
                }
            }
        }
    }

    private static void Swap(ref int first, ref int second)
    {
        var temp = first;
        first = second;
        second = temp;
    }

    // TODO: Add static Print function
    public static void Print(string text, int[] array)
    {
        Console.Write(text);
        foreach (var item in array)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }
}
internal class Program
{
    static void Main()
    {
        var values = new int[] { 5, 4, 3, 2, 1 };

        Sorter.Print("Not sorted: ", values);
        Sorter.BubbleSort(values);
        Sorter.Print("Sorted: ", values);

        Console.ReadLine();
    }
}
