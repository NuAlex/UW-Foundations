using System;
using System.Collections.Generic;

namespace InventoryApp
{
    internal static class TextUI
    {
        // Text UI Characters
        internal const char HorizontalLine = (char)(0x2500);
        internal const char VerticalLine = (char)(0x2502);


        // Centers a string on the screen
        public static string PadCenter(string s, char c)
        {
            if (s == null || Console.WindowWidth <= s.Length) return s;

            int padding = Console.WindowWidth - s.Length;
            return s.PadLeft(s.Length + padding / 2, c).PadRight(Console.WindowWidth, c);
        }


        public static void PrintCancelMessage()
        {
            Console.WriteLine("    | Type \"c\" to cancel | \n");
        }


        public static void PrintPause()
        {
            Console.Write("\n\n    // Press any key to continue // ");
            Console.ReadKey();
            ClearKeyboardBuffer();
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
            Console.WriteLine(PadCenter(title, ' '));
            Console.WriteLine();

            // Print 2nd line
            PrintLine();
            Console.WriteLine("\n\n");

        }


        // Skips all previous input chars
        public static void ClearKeyboardBuffer()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(false);
        }


        // Confirms user operation [y/n]
        public static ConsoleKey ConfirmOperation(string operation)
        {
            ConsoleKey response;
            Console.Write(operation);
            TextUI.ClearKeyboardBuffer();
            do
            {
                response = Console.ReadKey(true).Key;   // true is intercept key but dont show it, false shows the key
            }
            while (response != ConsoleKey.Y && response != ConsoleKey.N);
            return response;
        }


        // Reads user input and only accepts keys from the list of menu options
        public static ConsoleKey ReadMenuUserInput(Dictionary<ConsoleKey, string> menu)
        {
            // Get option from user
            ClearKeyboardBuffer();
            ConsoleKeyInfo info;
            string option;
            do
            {
                info = Console.ReadKey(true);
                if (menu.TryGetValue(info.Key, out option))
                {
                    return info.Key;
                }
            }
            while (true);
        }


        public static ConsoleKey PrintMainMenu(string shopName)
        {
            PrintTitle(shopName);
            Console.WriteLine("    |=|  MAIN MENU  |=|\n");
            // Build menu options
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

            return ReadMenuUserInput(menu);

        }


        public static ConsoleKey PrintSearchMenu()
        {
            // Build menu options
            Dictionary<ConsoleKey, string> menu = new Dictionary<ConsoleKey, string>();
            menu.Add(ConsoleKey.R, "    (R)emove Item");
            menu.Add(ConsoleKey.C, "    (C)hange Item");
            menu.Add(ConsoleKey.B, "    |    (B)ack to Main Menu");

            // Display menu optionsb
            string menuStr = "";
            foreach (var o in menu)
            {
                menuStr += o.Value;
            }
            Console.Write(menuStr);

            return ReadMenuUserInput(menu);
        }


        public static ConsoleKey PrintListMenu()
        {
            // Build menu options
            Dictionary<ConsoleKey, string> menu = new Dictionary<ConsoleKey, string>();
            menu.Add(ConsoleKey.I, "    > (I)D");
            menu.Add(ConsoleKey.D, "    (D)escription");
            menu.Add(ConsoleKey.P, "    (P)rice");
            menu.Add(ConsoleKey.C, "    (C)ost");
            menu.Add(ConsoleKey.Q, "    (Q)uantity");
            menu.Add(ConsoleKey.V, "    (V)alue");
            menu.Add(ConsoleKey.B, "    |    (B)ack to Main Menu");

            // Display menu options
            Console.WriteLine("    Sort by (ascending/descending): ");
            string menuStr = "";
            foreach (var o in menu)
            {
                menuStr += o.Value;
            }
            Console.Write(menuStr);

            return ReadMenuUserInput(menu);

        }


        public static void PrintAddOption(string shopName)
        {
            PrintTitle(shopName);
            Console.WriteLine("    |+|    ADD ITEM    |+|");
            PrintCancelMessage();
        }


        public static void PrintRemoveOption(string shopName)
        {
            PrintTitle(shopName);
            Console.WriteLine("    |-|  REMOVE ITEM   |-|");
            PrintCancelMessage();
        }


        public static void PrintChangeOption(string shopName)
        {
            PrintTitle(shopName);
            Console.WriteLine("    |*|  CHANGE ITEM   |*|");
            PrintCancelMessage();
        }


        public static void PrintListption(string shopName)
        {
            PrintTitle(shopName);
        }


        public static void PrintSearchOption(string shopName)
        {
            PrintTitle(shopName);
            Console.WriteLine("    |~|  SEARCH ITEM   |~|");
            PrintCancelMessage();
            Console.WriteLine("    // Search by Product ID is case-sensitive // \n");
        }

    } // Class TextUI
} // Namespace InventoryApp
