using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge01_3_PaycheckCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            decimal hoursWorked;
            decimal hoursExtra;
            decimal hourlyWage;
            decimal payCheck;

            while (true) 
            {
                // Init

                hoursWorked = 0;
                hoursExtra = 0;
                hourlyWage = 0;
                payCheck = 0;

                // Input information
                Console.WriteLine("Please provide the employee's week information:");
                
                Console.Write("Total worked hours (H)? ");
                hoursWorked = decimal.Parse(Console.ReadLine());
                
                Console.Write("Hourly wage ($)? ");
                hourlyWage = decimal.Parse(Console.ReadLine());

                // Calculate Paycheck
                if (hoursWorked == 0) 
                {
                    Console.WriteLine("Invalid working hours. \nWeek Payment Due = $0");
                }
                else
                {
                    if (hoursWorked > 40) 
                    {
                        hoursExtra = (hoursWorked - 40) * (decimal) 1.5;
                        hoursWorked = 40;
                    }

                    payCheck = (hoursWorked + hoursExtra) * hourlyWage;

                    Console.WriteLine("Employee worked {0} hours, plus {1} extra hours with a hourly wage of {2}. \nWeek Payment Due = {3}\n", 
                        hoursWorked.ToString(), hoursExtra.ToString(), hourlyWage.ToString(), payCheck.ToString());

                    Console.WriteLine("(Press CTRL + C to exit)\n\n");
                    
                }
            }    
        }
    }
}
