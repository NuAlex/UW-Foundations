using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework05_ExplorationSelfExam1
{
    internal class Program
    {

        /*
        static void Main(string[] args)
        {
        int iSum;
        int iCnt;//= Sum, iValue; //iTotal;
        char chChar = 'a';

        iSum = chChar
        ;
        while (iSum = 100) ;
        {
            iSum = iSum + 1;
        }

        static void Main()
        {
            int iX;
            int iY;

            iX = 15321;
            while (iX != 0)
            {
                iY = iX % 10;
                Console.Write(iY);
                iX /= 10;
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        static void Main()
        {
            uint usCnt; // Unsigned chars can never be less than 0!
            uint usSum = 0;

            for (usCnt = 10; usCnt >= 0; usCnt--)
            {
                Console.WriteLine("{0}", usCnt);
                usSum = usSum + usCnt;
            }
            Console.ReadLine();
        }

    */
        class MyStack : Stack<int>
        {
            public bool IsEmpty()
            {
                return !this.Any();
            }
        }

        static void Main()
        {
            //Stack<int> stack = new Stack<int> ();
            MyStack stack = new MyStack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            //while(!stack.IsEmpty)
            //while (stack.Count > 0)
            //while (stack.Any())
            while (!stack.IsEmpty())
            {
                Console.Write("{0}", stack.Pop());
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
