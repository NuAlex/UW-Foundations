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


        static decimal MaxUnitValue(OrderedDictionary dic)
        {
            // returns the first value of the OrderedDictionary
            var first = dic.GetEnumerator();
            first.MoveNext();
            DictionaryEntry maxUnit = (DictionaryEntry)first.Current;
            return (decimal) maxUnit.Value;
        }


        static void Main()
        {
            OrderedDictionary units = new OrderedDictionary();
            units.Add((string) "Bazillion", (decimal) 1000000000000000);
            units.Add((string) "Trillion",  (decimal) 1000000000000);
            units.Add((string) "Billion",   (decimal) 1000000000);
            units.Add((string) "Million",   (decimal) 1000000);
            units.Add((string) "Thousand",  (decimal) 1000);
            units.Add((string) "Dollars",   (decimal) 1);
            //PrintUnits(units);

            Dictionary<int, string> translateNumbers = new Dictionary<int, string>();
            translateNumbers.Add(1, "one");
            translateNumbers.Add(2, "two");
            translateNumbers.Add(3, "three");
            translateNumbers.Add(4, "four");
            translateNumbers.Add(5, "five");
            translateNumbers.Add(6, "six");
            translateNumbers.Add(7, "seven");
            translateNumbers.Add(8, "eight");
            translateNumbers.Add(9, "nine");
            translateNumbers.Add(10, "ten");
            translateNumbers.Add(11, "eleven");
            translateNumbers.Add(12, "twelve");
            translateNumbers.Add(13, "thirteen");
            translateNumbers.Add(14, "fourteen");
            translateNumbers.Add(15, "fifteen");
            translateNumbers.Add(16, "sixteen");
            translateNumbers.Add(17, "seventeen");
            translateNumbers.Add(18, "eighteen");
            translateNumbers.Add(19, "nineteen");
            translateNumbers.Add(20, "twenty");
            translateNumbers.Add(21, "twenty-one");
            translateNumbers.Add(22, "twenty-two");
            translateNumbers.Add(23, "twenty-three");
            translateNumbers.Add(24, "twenty-four");
            translateNumbers.Add(25, "twenty-five");
            translateNumbers.Add(26, "twenty-six");
            translateNumbers.Add(27, "twenty-seven");
            translateNumbers.Add(28, "twenty-eight");
            translateNumbers.Add(29, "twenty-nine");
            translateNumbers.Add(30, "thirty");
            translateNumbers.Add(31, "thirty-one");
            translateNumbers.Add(32, "thirty-two");
            translateNumbers.Add(33, "thirty-three");
            translateNumbers.Add(34, "thirty-four");
            translateNumbers.Add(35, "thirty-five");
            translateNumbers.Add(36, "thirty-six");
            translateNumbers.Add(37, "thirty-seven");
            translateNumbers.Add(38, "thirty-eight");
            translateNumbers.Add(39, "thirty-nine");
            translateNumbers.Add(40, "forty");
            translateNumbers.Add(41, "forty-one");
            translateNumbers.Add(42, "forty-two");
            translateNumbers.Add(43, "forty-three");
            translateNumbers.Add(44, "forty-four");
            translateNumbers.Add(45, "forty-five");
            translateNumbers.Add(46, "forty-six");
            translateNumbers.Add(47, "forty-seven");
            translateNumbers.Add(48, "forty-eight");
            translateNumbers.Add(49, "forty-nine");
            translateNumbers.Add(50, "fifty");
            translateNumbers.Add(51, "fifty-one");
            translateNumbers.Add(52, "fifty-two");
            translateNumbers.Add(53, "fifty-three");
            translateNumbers.Add(54, "fifty-four");
            translateNumbers.Add(55, "fifty-five");
            translateNumbers.Add(56, "fifty-six");
            translateNumbers.Add(57, "fifty-seven");
            translateNumbers.Add(58, "fifty-eight");
            translateNumbers.Add(59, "fifty-nine");
            translateNumbers.Add(60, "sixty");
            translateNumbers.Add(61, "sixty-one");
            translateNumbers.Add(62, "sixty-two");
            translateNumbers.Add(63, "sixty-three");
            translateNumbers.Add(64, "sixty-four");
            translateNumbers.Add(65, "sixty-five");
            translateNumbers.Add(66, "sixty-six");
            translateNumbers.Add(67, "sixty-seven");
            translateNumbers.Add(68, "sixty-eight");
            translateNumbers.Add(69, "sixty-nine");
            translateNumbers.Add(70, "seventy");
            translateNumbers.Add(71, "seventy-one");
            translateNumbers.Add(72, "seventy-two");
            translateNumbers.Add(73, "seventy-three");
            translateNumbers.Add(74, "seventy-four");
            translateNumbers.Add(75, "seventy-five");
            translateNumbers.Add(76, "seventy-six");
            translateNumbers.Add(77, "seventy-seven");
            translateNumbers.Add(78, "seventy-eight");
            translateNumbers.Add(79, "seventy-nine");
            translateNumbers.Add(80, "eighty");
            translateNumbers.Add(81, "eighty-one");
            translateNumbers.Add(82, "eighty-two");
            translateNumbers.Add(83, "eighty-three");
            translateNumbers.Add(84, "eighty-four");
            translateNumbers.Add(85, "eighty-five");
            translateNumbers.Add(86, "eighty-six");
            translateNumbers.Add(87, "eighty-seven");
            translateNumbers.Add(88, "eighty-eight");
            translateNumbers.Add(89, "eighty-nine");
            translateNumbers.Add(90, "ninety");
            translateNumbers.Add(91, "ninety-one");
            translateNumbers.Add(92, "ninety-two");
            translateNumbers.Add(93, "ninety-three");
            translateNumbers.Add(94, "ninety-four");
            translateNumbers.Add(95, "ninety-five");
            translateNumbers.Add(96, "ninety-six");
            translateNumbers.Add(97, "ninety-seven");
            translateNumbers.Add(98, "ninety-eight");
            translateNumbers.Add(99, "ninety-nine");
            //Console.WriteLine("Debug : {0}", translateNumbers[1]);

            bool validInput;
            decimal amount;
            decimal truncate;
            decimal remaining;
            decimal hundreds;
            decimal cents;

            while (true)
            {
                Console.Write("Please introduce the amount to money ($):");
                validInput = decimal.TryParse(Console.ReadLine(), out amount);

                // Validate maximum value
                // DictionaryEntry maxUnit = new DictionaryEntry();
                //maxUnit = units[0];
                if (amount > MaxUnitValue(units) * 1000)
                {
                    validInput = false;
                    Console.Write("Amount too high! ");
                }

                if (validInput)
                {
                    // Handle Cents
                    remaining = GetWholeValue(amount);
                    cents = GetFractionalValueAsWholeNumber(amount, 100);

                    // Got from Bazillions to Hundreds
                    foreach (DictionaryEntry unit in units)
                    {
                        truncate = GetWholeValue(remaining / (decimal)unit.Value);
                        if (truncate > 0)
                        {
                            // move floating point to next unit
                            remaining = remaining - (truncate * (decimal)unit.Value);

                            // Handle hundreds
                            hundreds = truncate / 100;
                            if (hundreds > 1)
                            {
                                Console.Write("{0} Hundred and ", translateNumbers[(int) GetWholeValue(hundreds)]);
                            }
                            Console.Write("{0} ", translateNumbers[(int) GetFractionalValueAsWholeNumber(hundreds, 0)]);

                            Console.Write("{0}, ", unit.Key.ToString());
                        }
                        
                    }

                    if (cents > 0)
                    {
                        Console.Write("and {0} cents.", translateNumbers[(int) cents]);
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
