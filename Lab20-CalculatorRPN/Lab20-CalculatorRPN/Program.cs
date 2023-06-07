// Create a basic RPN Calculator
// Make use of Class Stack to create your Class RPN Calculator 
using System;

class Stack
{
    private int[] stack = new int[10];
    private int sp = 0;

    public void Push(int v)
    {
        stack[sp++] = v;
    }

    public int Top
    {
        get
        {
            return stack[sp - 1];
        }
    }

    public bool IsEmpty
    {
        get
        {
            return sp == 0;
        }
    }

    public int Pop()
    {
        return stack[--sp];
    }
}

class RPN // design RPN
{
    private Stack stack = new Stack(); // create an object of class Stack

    // CORRECTION
    //public void Process(string str)
    //{
    //    switch (str)
    //    {
    //        case "+": // when user wants to add the last two numbers
    //            {
    //                // TODO: Pop 2 values off the stack     
    //                int v2 = stack.Pop();
    //                int v1 = stack.Pop();

    //                // Add them together
    //                // Push the result back onto the stack
    //                stack.Push(v1 + v2);
    //                break;
    //            }
    //        case "-": // when user wants to subtract the last two numbers
    //            {
    //                // TODO: Pop 2 values off the stack
    //                int v2 = stack.Pop();
    //                int v1 = stack.Pop();

    //                // Subtract them together
    //                // Push the result back onto the stack
    //                stack.Push(v1 - v2);
    //                break;
    //            }
    //        default: // when user enters a number
    //            {
    //                // TODO: place the number into the stack
    //                // step 1: convert str into an integer
    //                int v1 = int.Parse(str);

    //                // step 2: push the integer into the stack
    //                stack.Push(v1);
    //                break;
    //            }
    //    }
    //}


    public void Process(string str)
    {
        switch (str)
        {
            case "+": // when user wants to add the last two numbers
                {
                    // TODO:
                    if (stack.IsEmpty)
                    {
                        Console.WriteLine("ERROR: Add more parcels and try again");
                        return;
                    }
                    // Pop 2 values off the stack
                    int parcel1 = stack.Pop();
                    if (stack.IsEmpty)
                    {
                        stack.Push(parcel1);
                        Console.WriteLine("ERROR: Add more parcels and try again");
                        return;
                    }
                    int parcel2 = stack.Pop();
                    // Add them together
                    // Push the result back onto the stack
                    stack.Push(parcel1 + parcel2);
                    break; // do not forget to break
                }
            case "-": // when user wants to subtract the last two numbers
                {
                    // TODO:
                    if (stack.IsEmpty)
                    {
                        Console.WriteLine("ERROR: Add more parcels and try again.");
                        return;
                    }
                    // Pop 2 values off the stack
                    int parcel1 = stack.Pop();
                    if (stack.IsEmpty)
                    {
                        stack.Push(parcel1);
                        Console.WriteLine("ERROR: Add more parcels and try again.");
                        return;
                    }
                    int parcel2 = stack.Pop();
                    // Subtract them together
                    // Push the result back onto the stack
                    stack.Push(parcel2 - parcel1);
                    break;
                }
            //case "": // when user wants to subtract the last two numbers
            //    {
            //        Console.WriteLine("ERROR: Type a number or +/- operator.");
            //        break;
            //    }
                    default: // when user enters a number
                {
                    // TODO:
                    // places the number into the stack
                    // since the input is coming in as string
                    // you need to convert it into an interger type first
                    // then push the interger into the stack
                    // so....

                    // step 1: convert str into an integer
                    int newValue;
                    if (int.TryParse(str, out newValue))
                    {
                        // step 2: push the integer into the stack
                        stack.Push(newValue);
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Type a number or +/- operator.");
                    }

                    break;
                }
        }
    }

    public int Result
    {
        get
        {
            // do the code to return the last value
            // return the top value (or the result)
            return stack.Top;
        }
    }
}
    
class Program
{
    static void Main()
    {
        var rpn = new RPN();

        while (true)
        {
            Console.Write("RPN>");
            var str = Console.ReadLine();

            rpn.Process(str);

            Console.WriteLine("={0}", rpn.Result);
        }
    }
}

