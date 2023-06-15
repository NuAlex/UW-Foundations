using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Pilot06_ProjectDictionary1
{
    internal class Inventory
    {
        public Inventory(string Name)
        {
            ShopName = Name;
        }

        // Data structure
        public struct ShopItem
        {
            public string id;
            public string description;
            public decimal price;
            public decimal cost;
            public decimal quantity;
            public decimal value { get => price * quantity; }
        }

        Dictionary<string, ShopItem> items = new Dictionary<string, ShopItem>();

        // Variables
        public readonly string ShopName;

        // Constants 
        private const bool AllowNullOrEmpty = true; // Used in ReadUserInput(out string) to allow or prevent an empty user input

        // Methods
        public ShopItem GetValue(string key)
        {
            if (items.TryGetValue(key, out ShopItem item))
            {
                return item;
            }
            else
            {
                return new ShopItem();
            }

        }

        // Check if ShopItem key exists
        private bool ContainsKey(string key)
        {
            return items.ContainsKey(key);
        }


        // Print a Shop Item
        private void PrintItemAsList(ShopItem item)
        {
            Console.WriteLine();
            Console.WriteLine($"    Id:          {item.id}\n" +
                              $"    Description: {item.description}\n" +
                              $"    Price:       {item.price:C}\n" +
                              $"    Cost:        {item.cost:C}\n" +
                              $"    Quantity:    {item.quantity}\n");
        }

        // Print a Shop Item including item's Value property
        private void PrintItemAsListWithValue(ShopItem item)
        {
            PrintItemAsList(item);
            Console.WriteLine($"    Value:       {item.value}");
            /* TODO TEST
            Console.WriteLine();
            Console.WriteLine($"    Id:          {item.id}\n" +
                              $"    Description: {item.description}\n" +
                              $"    Price:       {item.price:C}\n" +
                              $"    Cost:        {item.cost:C}\n" +
                              $"    Quantity:    {item.quantity}\n" +
                              $"    Value:       {item.value}");
            */
        }


        // Overload to print all items of this class
        internal void PrintItemsAsTable()
        {
            PrintItemsAsTable(items);
        }

        // Show all items on the screen in a table format
        internal void PrintItemsAsTable(Dictionary<string, ShopItem> items)
        {
            /* int width = -40;
            Console.WriteLine("{0}| {1,12} | {2,-40} | {3,12:C} | {4,12:C} | {5,12} | {6,12} |",
                "",
                "ID",
                "Description",
                "Price",
                "Cost",
                "Quantity",
                "Value");
            */
            var v = TextUI.VerticalLine;
            Console.WriteLine($"{""}{v} {"ID",12} {v} {"Description",-40} {v} {"Price",12:C} {v} {"Cost",12:C} {v} {"Quantity",12} {v} {"Value",12} {v}");

            TextUI.PrintLine();

            foreach (KeyValuePair<string, ShopItem> item in items)
            {
                Console.WriteLine("{0}| {1,12} | {2,-40} | {3,12:C} | {4,12:C} | {5,12} | {6,12:C} |",
                    "",
                    item.Value.id,
                    item.Value.description,
                    item.Value.price,
                    item.Value.cost,
                    item.Value.quantity,
                    item.Value.value);
            }
            TextUI.PrintPause();
        }


        /* ReadUserInput - String overload
         * Prompts the user to input text,
         * Validates is user typed 'c' or 'C' to cancel operation
         * Outputs the user input to out variable
         */
        private bool ReadUserInput(string promptText, out string input, bool allowNullOrEmptyOutput)
        {
            // Keep asking for valid input if allowNullOrEmptyOutput == False
            do
            {
                Console.Write(promptText);
                input = Console.ReadLine();
            }
            while ((string.IsNullOrEmpty(input) && !allowNullOrEmptyOutput) ||
                    (!input.All(char.IsLetterOrDigit) && !allowNullOrEmptyOutput));


            // checked if user want to cancel
            if (input.ToLower().Equals("c"))
            {
                return false;
            }

            return true;
        }

        /* ReadUserInput - decimal overload
         * Prompts the user to input a decimal,
         * Validates is user typed 'c' or 'C' to cancel operation
         * Parses and outputs the user input to out decimal variable
         */
        private bool ReadUserInput(string promptText, out decimal inputDecimal)
        {
            Console.Write(promptText);
            string input = Console.ReadLine();
            inputDecimal = 0;

            // checked if user want to cancel
            if (input.ToLower().Equals("c"))
            {
                return false;
            }
            decimal.TryParse(input, out inputDecimal);
            return true;
        }

        /* ReadUserInput - Integer overload
         * Prompts the user to input an integer,
         * Validates is user typed 'c' or 'C' to cancel operation
         * Parses and outputs the user input to out integer variable
         */
        private bool ReadUserInput(string promptText, out int inputInt)
        {
            Console.Write(promptText);
            string input = Console.ReadLine();
            inputInt = 0;

            // checked if user want to cancel
            if (input.ToLower().Equals("c"))
            {
                return false;
            }
            int.TryParse(input, out inputInt);
            return true;
        }

        // Alows user to edit a given string
        // Used to change the current value of a field
        private static string EditReadLine(string input)
        {
            int pos = Console.CursorLeft;
            Console.Write(input);
            ConsoleKeyInfo info;
            List<char> chars = new List<char>();
            if (string.IsNullOrEmpty(input) == false)
            {
                chars.AddRange(input.ToCharArray());
            }

            while (true)
            {
                info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.Backspace && Console.CursorLeft > pos)
                {
                    chars.RemoveAt(chars.Count - 1);
                    Console.CursorLeft -= 1;
                    Console.Write(' ');
                    Console.CursorLeft -= 1;

                }
                else if (info.Key == ConsoleKey.Enter)
                {
                    Console.Write(Environment.NewLine);
                    break;
                }
                //Here you need create own checking of symbols
                else if (char.IsLetterOrDigit(info.KeyChar) || char.IsPunctuation(info.KeyChar))
                {
                    Console.Write(info.KeyChar);
                    chars.Add(info.KeyChar);
                }
            }
            return new string(chars.ToArray());
        }

        // Alows user to edit a given decimal value
        private static decimal EditReadLine(decimal input)
        {
            string inputStr = input.ToString();
            inputStr = EditReadLine(inputStr);
            decimal.TryParse(inputStr, out decimal result);
            return result;
        }

        // Alows user to edit a given int value
        private static int EditReadLine(int input)
        {
            string inputStr = input.ToString();
            inputStr = EditReadLine(inputStr);
            int.TryParse(inputStr, out int result);
            return result;
        }

        // Confirms user operation [y/n]
        private static ConsoleKey ConfirmOperation(string operation)
        {
            ConsoleKey response;
            Console.Write(operation);
            do
            {
                response = Console.ReadKey(true).Key;   // true is intercept key but dont show it, false shows the key
            }
            while (response != ConsoleKey.Y && response != ConsoleKey.N);
            return response;
        }


        private bool FindItemByDescription(string description)
        {
            //    items.wh
            //    return items.ContainsKey(key);
            return false;
        }

        // Read the input from the user
        // Returns false is user typed 'C' to cancel
        // Returns true if/when itemIf is found
        private bool FindItemByKey(out string itemId)
        {
            // Input item ID - Validate if not null and is exists
            bool itemKeyExists;
            do
            {
                if (!ReadUserInput("    Product ID? ", out itemId, !AllowNullOrEmpty))
                {
                    return false;
                }
                itemId = itemId.ToLower().Trim();
                itemKeyExists = ContainsKey(itemId);
                if (!itemKeyExists)
                {
                    Console.WriteLine("    ERROR: Item not found. Please try again.");
                }
            }
            while (!string.IsNullOrEmpty(itemId) && !itemKeyExists);

            return true;
        }

        // Add new item to Shop list
        internal void AddShopItem()
        {
            bool itemKeyExists;
            ShopItem newItem = new ShopItem();

            // TODO press escape to cancel/exit
            Console.WriteLine("    New Shop Item - Type \"c\" to cancel.\n");
            // Input item ID - Validate if not null and not duplicate
            do
            {
                if (!ReadUserInput("    Product ID? ", out newItem.id, !AllowNullOrEmpty)) { return; }
                itemKeyExists = ContainsKey(newItem.id.ToLower().Trim());
                if (itemKeyExists)
                {
                    Console.WriteLine("    ERROR: Item already exists. Use option \"Change Item\" to update the item.");
                }
            }
            while (!string.IsNullOrEmpty(newItem.id) && itemKeyExists);

            if (!ReadUserInput("    Description? ", out newItem.description, AllowNullOrEmpty)) { return; }
            if (!ReadUserInput("    Price? ", out newItem.price)) { return; }
            if (!ReadUserInput("    Cost? ", out newItem.cost)) { return; }
            if (!ReadUserInput("    Quantity? ", out newItem.quantity)) { return; }

            items.Add(newItem.id.ToLower().Trim(), newItem);
        }

        // Change a Shop item from the current list
        internal void ChangeItem()
        {
            TextUI.PrintTitle(ShopName);
            Console.WriteLine("    |*|  CHANGE ITEM  |*|\n");
            string changeItemId;
            if (!FindItemByKey(out changeItemId))
            {
                return;
            }
            // TODO press escape to cancel/exit
            TextUI.PrintTitle(ShopName);
            ShopItem changeItem = items[changeItemId];
            Console.WriteLine("    |*|  CHANGE ITEM  |*|");
            PrintItemAsList(changeItem);

            Console.WriteLine();
            Console.Write("    New Description: ");
            changeItem.description = EditReadLine(changeItem.description);
            Console.Write("    New Price: ");
            changeItem.price = EditReadLine(changeItem.price);
            Console.Write("    New Cost: ");
            changeItem.cost = EditReadLine(changeItem.cost);
            Console.Write("    New Quantity: ");
            changeItem.quantity = EditReadLine(changeItem.quantity);

            ConsoleKey response = ConfirmOperation("\n    Are you sure you want to update this item? [y/n] ");

            if (response == ConsoleKey.Y)
            {
                items[changeItemId] = changeItem;
                Console.WriteLine($"\n    Item '{changeItem.id}' updated successfully.");
                TextUI.PrintPause();
            }
        }


        // Show all items on the screen
        internal void RemoveItem()
        {
            // TODO press escape to cancel/exit
            string removeItemId;
            Console.WriteLine("    Remove Shop Item - Type \"c\" to cancel.\n");

            if (!FindItemByKey(out removeItemId))
            {
                return;
            }

            ShopItem removeItem = items[removeItemId];
            //ConsoleKey response;
            Console.WriteLine("\n    Remove item:");
            PrintItemAsList(removeItem);
            ConsoleKey response = ConfirmOperation("\n    Are you sure you want to PERMANENTLY DELETE this item? [y/n] ");

            if (response == ConsoleKey.Y)
            {
                items.Remove(removeItemId);
                Console.WriteLine($"\n    Item '{removeItem.id}' removed successfully.");
                TextUI.PrintPause();
            }

        }

    }
}
