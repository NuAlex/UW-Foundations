using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    internal class MyProtectedClass
    {

        protected string Name { get; set; }
    }

    internal class InheritedClass : MyProtectedClass
    {
        string Name2 { get; set; }
    }
    internal struct Coords
    {
        public Coords(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public override string ToString() => $"({X}, {Y})";
   
    }

static class Point2
    {

        public static void MyMethod()
        {
            //do something
        }

    }
    class Point
    {
        public Point()
        {
            // do something
        }
        public Point(double x, double y)
        {
            // do something
        }
    }

    static class Test
    {
        public static void TestMain()
        {
            int[] X = new int[10] { 0, 1, 4, 9, 16, 0, 0, 0, 0, 0 };
            int k;

            for (k = 5; k < 10; ++k)
            {
                X[k] = k * k;
            }

            for (k = 0; k < X.Length; k++)
            {
                Console.Write("{0}    ", X[k]);
            }
        }
    }


    class Factorial
    {
        public static void FactorialMain()
        {
            long nFactorial = 1;
            long nComputeTo = 5;

            long nCurDigit = 1;

            try
            {
                //long x = 1 / (1 - nFactorial);

                checked
                {
                    for (; nCurDigit <= nComputeTo; nCurDigit++)
                    {
                        nFactorial *= nCurDigit;
                    }
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Computing {0}! caused an overflow {1}",
                    nComputeTo, e.StackTrace);
                return;
            }

            Console.WriteLine("{0}! is {1}", nComputeTo, nFactorial);
        }
    }

/*
    class Shape
    {
    }
*/



internal class Program
    {

    public struct Student
    {
        string Name;
        string SSN;
        int ClassesTaken;
        char Grade;
    }

    /*
    enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }
    */

    static void Main(string[] args)
    {
        int[] numbers = new int[10];
        Console.WriteLine($"Size: {numbers.Length}");

        var strArray = new string[10,2];
        strArray[0, 0] = "1";
        strArray[0, 1] = "2";

        Console.WriteLine($"Array: ");
        foreach( string str in strArray ) { Console.WriteLine( str ); }

        Console.WriteLine($"Rank: {strArray.Rank}");
        Console.WriteLine($"Size: {strArray.Length}");
        //Console.WriteLine($"Count: {strArray.Count<string>()}");


        var p1 = new Coords(0, 0);
        Console.WriteLine(p1.X);  // output: (0, 0)

        string Str1 = "lala";
        string Str2 = "lala";
        Console.WriteLine(Str1 == Str2);

        Console.WriteLine($"--- --- ---");
        Point point = new Point();

        Point2.MyMethod();

        Console.WriteLine($"--- --- ---");

        Test.TestMain();

        Console.WriteLine($"--- --- ---");

        Factorial.FactorialMain();

        Console.WriteLine($"--- --- ---");

        //Shape s = new Shape();
        //Console.WriteLine(s);

        /*
        Console.WriteLine($"--- -27- ---");
        int[] xlist = new int[] { 9, 5, 3, -2, 4, 5 };

        for (int x = 0; x < xlist.Length; x++)
        {
            if (xlist[x] == 3)
            {
                for (int y = x; y < xlist.Length - 1; y++)
                {
                    xlist[y] = xlist[y + 1];
                }
            }
        }
        xlist[xlist.Length-1] = 0;

        foreach (int v in xlist)
        {
            Console.Write("{0} ", v);
        }
        */

        Console.WriteLine($"--- -28- ---");
        int[] xlist = new int[] { 7, -2 , 3, 9, -10, -2, 6};
        //int[] xlist = new int[] { 7, -2};

        for (int x = 0; x < xlist.Length - 1; x++)
        {
            if (xlist[x] > xlist[x + 1])
            {
                //int t = xlist[x];
                //xlist[x] = xlist[x + 1];
                //xlist[x + 1] = t;

                // This swap the values in one line
                (xlist[x], xlist[x + 1]) = (xlist[x + 1], xlist[x]);
                
                // This will restart the first loop and
                // begins sorting from the initial position. 
                x = -1; 
            }
        }

        foreach (int v in xlist)
        {
            Console.Write("{0} ", v);
        }




        Console.ReadLine();
        }
    }
