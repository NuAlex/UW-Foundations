using System;


internal class Program
{
    static void Main()
    {
        var tv = new Television();

        if (tv.On == false)
        {
            tv.On = true;
        }

        tv.Channel = 3;

        tv.Volume++;
        tv.Volume++;
        tv.Volume++;
        tv.Volume++;

        tv.On = false;

        Console.ReadLine();

    }

}
