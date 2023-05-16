using System;
using System.Collections.Generic;

// Poor implementation, does not expand the hundreds of tousands.

namespace Challenge01_4_PronounceMoney
{
    internal class Program
    {
        static void Main()
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

        /*
         * 
        // Spells hundreds and returns the whole number / 100
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

        // Truncates a number and returns only the decimal part
        public static decimal  ReturnDecimalPart(decimal value)
        {
            decimal wholeAmount = Math.Truncate(value);
            return (value - wholeAmount);

        }


        public struct Units
        {

            public string unitName;
            public long unitAmount;
        }

        // ======= MAIN =======
        static void Main()
        {
            var units = new Units[10];
            units.add
        }
        /*

        /* cant enumerate the values
        enum UnitsEnum : ulong
        {
            Hundred = 100,
            Thousand = 1000,
            Million = 1000000,
            Billion = 1000000000,
            Trillion = 1000000000000,
            Bazillion = 1000000000000000
        }

        // ======= MAIN =======
        static void Main()
        {
            var units = new UnitsEnum();
            Console.WriteLine(units.'Hundred');

            foreach (UnitsEnum unit in (UnitsEnum[]) Enum.GetValues(typeof(UnitsEnum)))
            {
                string name = unit.ToString();
                Console.WriteLine(units.Hundred);
            }
            Console.ReadLine();
        }

        /*



        /*

            // ======= MAIN =======
            static void Main()
            {
                decimal amount;
                decimal wholeAmount;
                int cents;
                bool validInput;
                int millions;
                int thousands;
                int hundreds;
                enum unit = UnitsEnum;
                //Hashtable UnitsTable = new Hashtable()
                //{
                //    // Key , Value
                //    { "Hundred", 100 },
                //    { "Thousand", 1000 },
                //    { "Million", 1000000 },
                //    { "Billion", 1000000000 },
                //    { "Trillion", 1000000000000 },
                //    { "Bazillion", 1000000000000000 }
                //};



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

                        foreach (var u in units)
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
        */
    }
}
