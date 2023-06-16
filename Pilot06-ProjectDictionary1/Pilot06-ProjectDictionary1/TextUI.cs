using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot06_ProjectDictionary1
{
    internal static class TextUI
    {
        const char HorizontalLine = (char)(0x2500);
        // TODO shouln't be public
        public const char VerticalLine = (char)(0x2502);

        public static string PadCenter(string s, int width, char c)
        {
            if (s == null || width <= s.Length) return s;

            int padding = width - s.Length;
            return s.PadLeft(s.Length + padding / 2, c).PadRight(width, c);
        }

        public static void PrintPause()
        {
            Console.Write("\n\n    // Press any key to continue // ");
            Console.Read();
        }

        public static void PrintLine()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write(HorizontalLine);
            }
            Console.WriteLine();
        }


        public static void PrintTitle(string title)
        {
            // Print 1st line
            Console.Clear();
            PrintLine();

            // Print Title
            double middle = (Console.WindowWidth - title.Length) / 2;
            int startTitle = (int)Math.Round(middle);

            Console.WriteLine();
            Console.WriteLine(PadCenter(title, Console.WindowWidth, ' '));
            Console.WriteLine();

            // Print 2nd line
            PrintLine();
            Console.WriteLine("\n\n");

        }

        public static void PrintMenu(List<string> Menu)

        {
            foreach (string option in Menu)
            {
                Console.WriteLine(option);
            }
            Console.Write("\n >> ");
        }

        /*
        public static int DisplayMainMenu()
        {
            string menuChoice;
            int selectedOption;
            bool intParsed;
            List<string> MenuList = new List<string>
            {
                "    1 - Add a shop item",
                "    2 - Change shop item",
                "    3 - Remove shop item",
                "    4 - List shop items",
                "    0 - Exit"
            };

            do
            {
                PrintTitle("PET SHOP - LOVELY PUPPIES");
                PrintMenu(MenuList);
                menuChoice = Console.ReadLine();
                intParsed = int.TryParse(menuChoice, out selectedOption);
            }
            while (selectedOption < 0 || selectedOption > MenuList.Count - 1 || !intParsed);

            return selectedOption;
        }
        */
        public static ConsoleKey DisplayMainMenu()
        {
            // Build options
            Dictionary<ConsoleKey, string> menu = new Dictionary<ConsoleKey, string>();
            menu.Add(ConsoleKey.A, "    (A)dd Item");
            menu.Add(ConsoleKey.R, "    (R)emove Item");
            menu.Add(ConsoleKey.C, "    (C)hange Item");
            menu.Add(ConsoleKey.L, "    (L)ist Items");
            menu.Add(ConsoleKey.S, "    (S)earch Items");
            menu.Add(ConsoleKey.Oem102, ""); // line space
            menu.Add(ConsoleKey.X, "    E(X)IT");

            // Display menu options
            foreach (var o in menu)
            {
                Console.WriteLine(o.Value);
            }

            // Get option from user
            ConsoleKeyInfo info;
            string option;
            do
            {
                info = Console.ReadKey(true);
                if (menu.TryGetValue(info.Key, out option))
                {
                    //Console.WriteLine(option);
                    return info.Key;
                }
            }
            while (true);
        }

    }

}
