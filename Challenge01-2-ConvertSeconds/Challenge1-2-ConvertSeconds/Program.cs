using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_2_ConvertSeconds
{
    internal class Program
    {
        static void Main()
        {

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
                Console.WriteLine("Please insert the number of seconds to convert:");
                int seconds;

                if (int.TryParse(Console.ReadLine(), out seconds))
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

                    Console.WriteLine("Result: {0} days, {1} hours, {2} minutes and {3} seconds.", totalDays, totalHours, totalMinutes, totalSeconds);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                Console.WriteLine("\nPress CRTL+C to exit.\n");
            } while (true);



            //Console.ReadLine();


        }
    }
}
