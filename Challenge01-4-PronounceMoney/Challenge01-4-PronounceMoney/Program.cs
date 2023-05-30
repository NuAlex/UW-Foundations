using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlTypes;


namespace Challenge01_4_PronounceMoney
{
    internal class Program
    {
        static void PrintUnits(OrderedDictionary dic)
        {
            foreach (DictionaryEntry pair in dic) 
            {
                Console.WriteLine("{0} | {1}", pair.Key.ToString(), pair.Value);
            }
        }

        static decimal GetWholeValue(decimal value)
        {
            return Math.Truncate(value);
        }


        static decimal GetFractionalValue(decimal value)
        {
            // get the whole part
            decimal whole = Math.Truncate(value);
            // get the fractional part
            decimal fractional = value - whole;
            return fractional;
        }
        // Precision: 0 for automatic precision, 100 for #.##, 1000 for #.###... etc
        static decimal GetFractionalValueAsWholeNumber(decimal value, int precision)
        {
            decimal fractional = GetFractionalValue(value);
            decimal power;
            if (precision == 0)
            {
                // calcule precision
                // count the number of fractional digits  
                double countFractionalDigits = CountFractionalDigits(fractional);
                // get necessary power to convert fraction to whole number
                power = (decimal)Math.Pow(10, countFractionalDigits);
            }
            else
            {
                power = precision;
            }

            // return the fractional part as a whole number
            decimal fractionalPowered = fractional * power;
            return Math.Truncate(fractionalPowered);
        }

        static decimal CountWholeDigits(decimal value)
        {
            int count = 0;
            while (value > 0)
            {
                value/=10;
                count++;
            }
            return count;
        }

        static double CountFractionalDigits(decimal value)
        {
            int count = 0;
            while ((decimal)Math.Truncate(value) * 10 != (decimal)value * 10)
            {
                value *= 10;
                count++;
            }
            return count;
        }

        static void Main()
        {
            OrderedDictionary units = new OrderedDictionary();

            units.Add((string) "Bazillion", (decimal) 1000000000000000);
            units.Add((string) "Trillion",  (decimal) 1000000000000);
            units.Add((string) "Billion",   (decimal) 1000000000);
            units.Add((string) "Million",   (decimal) 1000000);
            units.Add((string) "Thousand",  (decimal) 1000);
            //units.Add((string) "Hundred",   (decimal) 100);
            PrintUnits(units);

            bool validInput;

            decimal amount;
            decimal amountInteger;
            decimal truncate;
            decimal remaining;
            
            decimal millions;
            decimal thousands;
            decimal hundreds;
            decimal cents;

            while (true)
            {
                Console.Write("Please introduce the amount to money ($):");
                validInput = decimal.TryParse(Console.ReadLine(), out amount);

                if (validInput)
                {
                    // Handle Cents
                    //amountInteger = (int) Math.Truncate(amount);
                    //cents = (int) ((amount - amountInteger) * 100);
                    amountInteger = GetWholeValue(amount);
                    cents = GetFractionalValueAsWholeNumber(amount, 100);
                    //Console.WriteLine("{0} and {1} cents", amountInteger, cents);

                    remaining = amountInteger;
                    // Handle Bazillions to Thousands
                    foreach (DictionaryEntry unit in units)
                    {
                        truncate = GetWholeValue(remaining / (decimal)unit.Value);
                        if (truncate > 0)
                        {
                            // move floating point to next unit
                            remaining = remaining - (truncate * (decimal)unit.Value);

                            // Handle Unit
                            //Console.WriteLine("++ {0}", truncate);

                            // Handle hundreds
                            hundreds = truncate / 100;
                            if (hundreds > 1)
                            {
                                Console.Write(" {0} hundred and", GetWholeValue(hundreds));
                            }
                            Console.Write(" {0}", GetFractionalValueAsWholeNumber(hundreds, 0));

                            Console.Write(" {0}", unit.Key.ToString());
                        }
                        
                    }

                    if (cents > 0)
                    {
                        Console.Write("{0} Dollars and {0} cents.", amountInteger);
                    }
                    else
                    {
                        Console.Write("and {0} Dollars.", amountInteger);
                    }

                    /*
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
                    */
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
