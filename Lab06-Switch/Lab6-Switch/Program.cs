// Ask user to input a month number 1, or 2, or 3 for (Jan, Feb, and Mar).
// Then check how many days each month has (say 31, 29, 30 days for each).
// Print the month and the number of days to screen.
// Finish the rest of exercise on your own and include all the months of the year.

using System;

namespace Lab6_Switch
{
    internal class Program
    {
        static void Main()
        {
            string monthNumber;
            string month;
            int daysOfTheMonth = 0;

            do
            {
                Console.Write("Please enter a month number (1 to 12): ");
                monthNumber = Console.ReadLine();

                switch (monthNumber)
                {
                    case "1":
                        month = "January";
                        daysOfTheMonth = 31;
                        break;
                    case "2":
                        month = "February";
                        daysOfTheMonth = 29;
                        break;

                    case "3":
                        month = "March";
                        daysOfTheMonth = 31;
                        break;

                    case "4":
                        month = "April";
                        daysOfTheMonth = 30;
                        break;

                    case "5":
                        month = "May";
                        daysOfTheMonth = 31;
                        break;

                    case "6":
                        month = "June";
                        daysOfTheMonth = 30;
                        break;

                    case "7":
                        month = "July";
                        daysOfTheMonth = 31;
                        break;

                    case "8":
                        month = "August";
                        daysOfTheMonth = 31;
                        break;

                    case "9":
                        month = "September";
                        daysOfTheMonth = 30;
                        break;

                    case "10":
                        month = "October";
                        daysOfTheMonth = 31;
                        break;

                    case "11":
                        month = "November";
                        daysOfTheMonth = 30;
                        break;

                    case "12":
                        month = "December";
                        daysOfTheMonth = 31;
                        break;

                    default:
                        month = "{INVALID!}";
                        daysOfTheMonth = 0;
                        break;
                }
                if (daysOfTheMonth == 0)
                {
                    Console.WriteLine("The month {0} is invalid! Please try again.\n", monthNumber);
                }
                else
                {
                    Console.WriteLine("The month {0} has {1} days.\n", month, daysOfTheMonth);
                }
                Console.WriteLine("(Press CTRL+C to exit.)\n");

            } while (true);
        }
    }
}
