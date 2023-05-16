using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Challenge01_4_PronounceMoney
{
    internal class Program
    {
        public enum UnitsEnum : ulong
        {
            Hundred   = 100,
            Thousand  = 1000,
            Million   = 1000000,
            Billion   = 1000000000,
            Trillion  = 1000000000000,
            Bazillion = 1000000000000000
        }


        // Pronouces hundreds and returns only the whole number / 100
        public static string breakHundreds(decimal value)
        {
            int hundreds;
            int tenths;
            decimal whole = Math.Truncate(value / 100);
            int decimalPart = (int) (value - whole);

            hundreds = (int) Math.Truncate((decimal) decimalPart / 100);
            tenths = decimalPart - (hundreds * 100);
            if (hundreds > 0)
            {
                return string.Format("{0} hundred and {1}", hundreds, tenths);
            }
            else
            {
                return "<no hundreds>";
            }



        }
        public static decimal  ReturnDecimalPart(decimal value)
        {
            decimal wholeAmount = Math.Truncate(value);
            return (value - wholeAmount);

        }



        static void Main()
        {
            decimal amount;
            decimal wholeAmount;
            int cents;
            bool validInput;
            int millions;
            int thousands;
            int hundreds;

            Hashtable UnitsTable = new Hashtable()
            {
                // Key , Value
                {"Hundred",   100},
                {"Thousand",  1000},
                {"Million",   1000000},
                {"Billion",   1000000000},
                {"Trillion",  1000000000000},
                {"Bazillion", 1000000000000000},
            };


            while (true)
            {
                Console.Write("Please introduce the amount to money ($) (v2): ");
                validInput = decimal.TryParse(Console.ReadLine(), out amount);

                if (validInput)
                {
                    //wholeAmount = (int) Math.Truncate(amount);
                    //cents = (int)((amount - wholeAmount) * 100);

                    cents = (int) (ReturnDecimalPart(amount) * 100);
                    wholeAmount = (int) Math.Truncate(amount);

                    foreach (var u in UnitsTable)
                    {
                        Console.WriteLine(u.Key);
                        Console.WriteLine(u.Value);
                    }

                    if (cents > 0)
                    {
                        Console.Write("{0} Dollars and {1} cents.", wholeAmount, cents);
                    }
                    else
                    {
                        Console.Write("and {0} Dollars.", wholeAmount);
                    }

                    breakHundreds(wholeAmount);

                }
                else
                {
                    Console.WriteLine("Invalid amount! Please try again.");
                }

                Console.WriteLine("\n(Press CTRL+C to exit.)\n\n");
            }


        }



        static void MainOLD()
        {

            decimal amount;
            decimal amountInteger;
            bool validInput;
            int millions;
            int thousands;
            int hundreds;
            int cents;

            while (true)
            {
                Console.Write("Please introduce the amount to money ($):");
                validInput = decimal.TryParse(Console.ReadLine(), out amount);

                if (validInput )
                {
                    amountInteger = (int) Math.Truncate(amount);
                    cents = (int) ((amount - amountInteger) * 100);

                    millions = (int) Math.Truncate(amountInteger / 1000000);
                    if ( millions > 0 )
                    {
                        Console.Write("{0} Million, ", millions);
                        amountInteger -= (millions * 1000000);
                    }

                    thousands = (int) Math.Truncate(amountInteger / 1000);
                    if (thousands > 0)
                    {
                        Console.Write("{0} Thousand, ", thousands);
                        amountInteger -= (thousands * 1000);
                    }

                    hundreds = (int)Math.Truncate(amountInteger / 100);
                    if (hundreds > 0)
                    {
                        Console.Write("{0} Hundred, ", hundreds);
                        amountInteger -= (hundreds * 100);
                    }

                    if (cents > 0)
                    {
                        Console.Write("{0} Dollars and {0} cents.", amountInteger);
                    }
                    else
                    {
                        Console.Write("and {0} Dollars.", amountInteger);
                    }                    
                }
                else
                {
                    Console.WriteLine("Invalid amount! Please try again.");
                }

                Console.WriteLine("\n(Press CTRL+C to exit.)\n\n");
            }


        }
    }
}
