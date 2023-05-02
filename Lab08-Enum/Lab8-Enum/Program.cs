using System;

namespace Lab8_Enum
{
    internal class Program
    {
        enum MonthNames
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
        enum MonthDays
        {
            January = 30,
            February = 29,
            March = 31,
            April = 30,
            May = 31,
            June = 30,
            July = 31,
            August = 31,
            September = 30,
            October = 31,
            November = 30,
            December = 31,
        }


        static void Main(string[] args)
        {

            MonthNames eName;

            do
            {
                Console.Write("Please enter a Month Number: ");
                string monthNumber = Console.ReadLine();

                int nDays = 0;

                switch (monthNumber)
                {
                    case "1":
                        eName = MonthNames.January;
                        nDays = (int)MonthDays.January;
                        break;
                    case "2":
                        eName = MonthNames.February;
                        nDays = (int)MonthDays.February;
                        break;
                    case "3":
                        eName = MonthNames.March;
                        nDays = (int)MonthDays.March;
                        break;
                    case "4":
                        eName = MonthNames.April;
                        nDays = (int)MonthDays.April;
                        break;
                    case "5":
                        eName = MonthNames.May;
                        nDays= (int)MonthDays.May;
                        break;
                    case "6":
                        eName = MonthNames.June;
                        nDays=(int)MonthDays.June;
                        break;
                    case "7":
                        eName = MonthNames.July;
                        nDays = (int)MonthDays.July;
                        break;
                    case "8":
                        eName = MonthNames.August;
                        nDays = (int)MonthDays.August;
                        break;
                    case "9":
                        eName = MonthNames.September;
                        nDays = (int)MonthDays.September;
                        break;
                    case "10":
                        eName = MonthNames.October;
                        nDays = (int)MonthDays.October;
                        break;
                    case "11":
                        eName = MonthNames.November;
                        nDays = (int)MonthDays.November; 
                        break;
                    default:
                        eName = MonthNames.December;
                        nDays = (int)MonthDays.December;
                        break;
                }
                Console.WriteLine("Month {0} has {1} days\n\n", eName, nDays);

            } while (true);


        }
    }
}
