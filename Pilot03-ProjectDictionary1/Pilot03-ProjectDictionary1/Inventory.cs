using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Pilot03_ProjectDictionary1
{
    public class Inventory
    {

        public struct ShopItem
        {
            public string id;
            public string description;
            public decimal price;
            public decimal cost;
            public int quantity;
            //decimal value;
        }

        Dictionary<string, ShopItem> items = new Dictionary<string, ShopItem>()
        {
            {"abc121", new ShopItem {id = "ABC121", description = "Dog1", price = 123.99m, cost = 90.10m, quantity = 1} },
            {"abc123", new ShopItem {id = "ABC123", description = "Dog3", price = 123.99m, cost = 90.10m, quantity = 3} },
            {"abc122", new ShopItem {id = "ABC122", description = "Dog2", price = 123.99m, cost = 90.10m, quantity = 2} }
        };

        const bool AllowNullOrEmpty = true;
        const bool DenyNullOrEmpty = false;

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
            Console.WriteLine("\n" +
                              "    Id:          {0}\n" +
                              "    Description: {1}\n" +
                              "    Price:       {2:C}\n" +
                              "    Cost:        {3:C}\n" +
                              "    Quantity:    {4}",
                              item.id, 
                              item.description, 
                              item.price, 
                              item.cost, 
                              item.quantity
                              // TODO ,item.value 
                              );
        }

        /* ReadUserInput - String overload
         * Prompts the user to input text,
         * Validates is user typed 'c' or 'C' to cancel operation
         * Outputs the user input to out variable
         */
        private bool ReadUserInput(string prompt, bool allowEmptyOut, out string input) 
        {
            // Keep asking for valid input if allowEmptyOut == False
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            }
            while ((string.IsNullOrEmpty(input) && !allowEmptyOut) ||
                    (!input.All(char.IsLetterOrDigit) && !allowEmptyOut));


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
        private bool ReadUserInput(string prompt, out decimal inputDecimal)
        {
            Console.Write(prompt);
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
        private bool ReadUserInput(string prompt, out int inputInt)
        {
            Console.Write(prompt);
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

        // Add new item to Shop list
        internal void AddShopItem()
        {
            bool itemKeyExists;
            ShopItem newItem = new ShopItem();

            Console.WriteLine("    New Shop Item - Type \"c\" to cancel.\n");
            // Input item ID - Validate if not null and not duplicate
            do
            {
                if (!ReadUserInput("    Product ID? ", DenyNullOrEmpty, out newItem.id)) { return; }
                itemKeyExists = ContainsKey(newItem.id.ToLower().Trim());
                if (itemKeyExists)
                {
                    Console.WriteLine("    ERROR: Item already exists. Use option \"Change Item\" to update the item.");
                }
            }
            while (!string.IsNullOrEmpty(newItem.id) && itemKeyExists);

            if (!ReadUserInput("    Description? ", AllowNullOrEmpty, out newItem.description))   { return; }
            if (!ReadUserInput("    Price? ", out newItem.price))                                 { return; }
            if (!ReadUserInput("    Cost? ", out newItem.cost))                                   { return; }
            if (!ReadUserInput("    Quantity? ", out newItem.quantity))                           { return; }

            items.Add(newItem.id.ToLower().Trim(), newItem);
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
                if (!ReadUserInput("    Product ID? ", DenyNullOrEmpty, out itemId)) 
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

        // Change a Shop item from the current list
        internal void ChangeItem()
        {
            string changeItemId;
            if (!FindItemByKey(out changeItemId))
            {
                return;
            }

            ShopItem changeItem = items[changeItemId];
            Console.WriteLine("");
            PrintItemAsList(changeItem);

            Console.WriteLine();
            Console.Write("    Description: ");
            changeItem.description = EditReadLine(changeItem.description);
            Console.Write("    Price: ");
            changeItem.price = EditReadLine(changeItem.price);
            Console.Write("    Cost: ");
            changeItem.cost = EditReadLine(changeItem.cost);
            Console.Write("    Quantity: ");
            changeItem.quantity = EditReadLine(changeItem.quantity);

            Console.WriteLine("\n    Update item:");
            PrintItemAsList(changeItem);
            ConsoleKey response = ConfirmOperation("\n    Are you sure you want to update this item? [y/n] ");
            /*
            Console.WriteLine("\n    Update item:");
            PrintItemAsList(changeItem);
            Console.Write("\n    Are you sure you want to update this item? [y/n] ");
            do
            {
                response = Console.ReadKey(true).Key;   // true is intercept key but dont show it, false shows the key
            }
            while (response != ConsoleKey.Y && response != ConsoleKey.N);
            */
            if (response == ConsoleKey.Y)
            {
                items[changeItemId] = changeItem;
                Console.WriteLine("\n\n    Item '{0}' removed. Press any key to continue.", changeItem.id);
                Console.ReadLine();
            }
        }


        // Show all items on the screen
        internal void RemoveItem()
        {
            string removeItemId;
//            bool itemKeyExists;

            Console.WriteLine("    Remove Shop Item - Type \"c\" to cancel.\n");

            /*
            // Input item ID - Validate if not null and is exists
            do
            {
                if (!ReadUserInput("    Product ID? ", DenyNullOrEmpty, out removeItemId)) { return; }
                removeItemId = removeItemId.ToLower().Trim();
                itemKeyExists = ContainsKey(removeItemId);
                if (!itemKeyExists)
                {
                    Console.WriteLine("    ERROR: Item not found. Please try again.");
                }
            }
            while (!string.IsNullOrEmpty(removeItemId) && !itemKeyExists);

            */
            if (!FindItemByKey(out removeItemId))
            {
                return;
            }
            
            ShopItem removeItem = items[removeItemId];
            //ConsoleKey response;
            Console.WriteLine("\n    Remove item:");
            PrintItemAsList(removeItem);
            ConsoleKey response = ConfirmOperation("\n    Are you sure you want to PERMANENTLY DELETE this item? [y/n] ");


            /*
            Console.Write("\n    Are you sure you want to PERMANENTLY DELETE this item? [y/n] ");
            do
            {
                response = Console.ReadKey(true).Key;   // true is intercept key but dont show it, false shows the key
            } 
            while (response != ConsoleKey.Y && response != ConsoleKey.N);
            */
            if (response == ConsoleKey.Y)
            {
                items.Remove(removeItemId);
                Console.WriteLine("\n\n    Item '{0}' removed. Press any key to continue.", removeItem.id);
                Console.ReadLine();
            }
            
        }


        // Show all items on the screen
        internal void PrintAllItems()
        {
            //Console.WriteLine("{0,10} | {1,20} | {2,10} | {3,10} | {4,10}",
            Console.WriteLine("{0,3} | {1,10} | {2,-40} | {3,20:C} | {4,20:C} | {5,20} | ",
                " ",
                "ID",
                "Description",
                "Price",
                "Cost",
                "Quantity");

            TextUI.PrintLine();

            foreach (KeyValuePair<string, ShopItem> item in items)
            {
                Console.WriteLine("{0,3} | {1,10} | {2,-40} | {3,20:C} | {4,20:C} | {5,20} | ", 
                    " ",
                    item.Value.id, 
                    item.Value.description, 
                    item.Value.price, 
                    item.Value.cost, 
                    item.Value.quantity);
                /*
                Console.WriteLine("{0,-5} | {1,-20} | {2,10:C}",
                    item.Value.id,
                    item.Value.description,
                    item.Value.price.ToString());
                */
            }
            Console.Write("\n\n    Press any key to continue.");
            Console.Read();
        }



        /*
        public Inventory(string id, string description, decimal price, decimal cost, decimal value, int quantity)
        {
            this.id = id;
            this.description = description;


        }


        public static Dictionary<string, ShopItem> ShopInventorySamples()
        {
            ShopItem shopItem1 = new ShopItem("ABC121", "Dog1", (decimal)123.99, (decimal)90.10, 1, 2);
            ShopItem shopItem2 = new ShopItem("ABC122", "Dog2", (decimal)123.99, (decimal)90.10, 1, 2);
            ShopItem shopItem3 = new ShopItem("ABC123", "Dog3", (decimal)123.99, (decimal)90.10, 1, 2);

            Dictionary<string, ShopItem> shopItemsSample = new Dictionary<string, ShopItem>();

            shopItemsSample.Add(shopItem1.id, shopItem1);
            shopItemsSample.Add(shopItem2.id, shopItem2);
            shopItemsSample.Add(shopItem3.id, shopItem3);

            return shopItemsSample;
        }
        */

    }
    }
