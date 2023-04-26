using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_2_ConvertSeconds
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int secondsPerMinute = 60;
            int secondsPerHour = 60 * secondsPerMinute;
            int secondsPerDay = 24 * secondsPerHour;

            do
            {
                Console.WriteLine("Please insert the number of seconds to convert:");
                int seconds;

                if (int.TryParse(Console.ReadLine(), out seconds))
                {
                    Console.WriteLine("Converting {0} seconds...", seconds);
                    int TotalDays = seconds / secondsPerDay;
                    int TotalHours;
                    int TotalMinutes;
                    int TotalSeconds;

                    Console.WriteLine("Result: {0} days, {1} hours, {2} minutes and {3} seconds.", TotalDays, TotalHours, TotalMinutes, TotalSeconds);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

            } while (true);



            //Console.ReadLine();


        }
    }
}
