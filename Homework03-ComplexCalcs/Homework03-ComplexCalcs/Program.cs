/*
 * Write a program that takes seconds and converts it into days, hours, minutes, and seconds.
 * 
 * For example if the user enters 129023, your program should output:
 * 
 * 1 days, 11 hours, 50 minutes, and 23 seconds
 * 
 * 
 * Submit Program.cs
 * Hint: Look at the % operator.
 * Hint: Have a variable that has the number seconds per day (86400), the number seconds per hour (3600), and the number seconds per minute (60).
 * Hint: Do not use the TimeSpan object. Feel free to investigate it as a solution, but do not use it in your final solution.
 * https://learn.microsoft.com/en-us/dotnet/api/system.timespan?view=net-8.0
*/

using System;

namespace Homework03_ComplexCalcs
{
    internal class Program
    {
        static void Main()
        {
            int seconds;
            int secondsPerMinute = 60;
            int secondsPerHour = 60 * secondsPerMinute;
            int secondsPerDay = 24 * secondsPerHour;
            int remaining;
            int totalDays;
            int totalHours;
            int totalMinutes;
            int totalSeconds;

            do
            {
                Console.Write("Please insert the number of seconds to convert: ");
                int.TryParse(Console.ReadLine(), out seconds);

                // Exploring the TimeSpan object just for fun - not used in calculation
                TimeSpan timeSpan = new TimeSpan(0, 0, seconds);

                if (seconds > 0)
                {
                    //Console.WriteLine("Converting {0} seconds...", seconds);
                    // Calculate Days
                    totalDays = seconds / secondsPerDay;

                    // Calculate Hours
                    remaining = seconds % secondsPerDay;
                    totalHours = remaining / secondsPerHour;

                    // Calculate Minutes
                    remaining = remaining % secondsPerHour;
                    totalMinutes = remaining / secondsPerMinute;

                    // Calculate Seconds
                    totalSeconds = remaining % secondsPerMinute;

                    // Show results
                    Console.WriteLine("Result calculated: {0} days, {1} hours, {2} minutes and {3} seconds.", totalDays, totalHours, totalMinutes, totalSeconds);
                    Console.WriteLine("Result in TimeSpan: {0}", timeSpan);
                    
                    // Compare calculated result with TimeSpan
                    if (timeSpan.Days == totalDays && 
                        timeSpan.Hours == totalHours && 
                        timeSpan.Minutes == totalMinutes && 
                        timeSpan.Seconds == totalSeconds)
                    {
                        // TimeSpan matches the calculation
                        Console.WriteLine("Calculated result in the same as TimeSpan!");
                    }
                    else
                    {
                        // Shouln't ever happen
                        Console.WriteLine("Something went wrong! Calculated result in NOTE the same as TimeSpan.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                Console.WriteLine("\nPress CRTL+C to exit.\n");

            } while (true);
        }
    }
}
