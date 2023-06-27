using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace InventoryApp
{
    internal class Inventory
    {
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

        // Collection of items
        internal Dictionary<string, ShopItem> items = new Dictionary<string, ShopItem>();

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
        } // GetValue


        // Check if ShopItem key exists
        private bool ContainsKey(string key)
        {
            return items.ContainsKey(key);
        } // including Value property


        // Print a Shop Item as a list of properties
        private void PrintItemAsList(ShopItem item)
        {
            Console.WriteLine();
            Console.WriteLine($"    Id:          {item.id}\n" +
                              $"    Description: {item.description}\n" +
                              $"    Price:       {item.price:C}\n" +
                              $"    Cost:        {item.cost:C}\n" +
                              $"    Quantity:    {item.quantity}");
        }

        // Print a Shop Item as a list of properties, including the Value property
        private void PrintItemAsListWithValue(ShopItem item)
        {
            PrintItemAsList(item);
            Console.WriteLine($"    Value:       {item.value}");
            Console.WriteLine();

        } // PrintItemAsListWithValue


        // Show all items on the screen in a table format
        internal void PrintItemsAsTable(Dictionary<string, ShopItem> items)
        {
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
            Console.WriteLine();

        } // PrintItemsAsTable


        /* ReadUserInput - String overload
         * Prompts the user to input text,
         * Validates is user typed 'c' or 'C' to cancel operation
         * Outputs the user input to out variable */
        private bool ReadUserInput(string promptText, out string input, bool allowNullOrEmptyOutput)
        {
            // Keep asking for valid input if allowNullOrEmptyOutput == False
            do
            {
                Console.Write(promptText);
                input = Console.ReadLine();
                if (!input.All(char.IsLetterOrDigit) && !allowNullOrEmptyOutput)
                {
                    Console.WriteLine("    > ERROR: Product ID can only contain letters or digits.");
                }
            }
            while ((string.IsNullOrEmpty(input) && !allowNullOrEmptyOutput) ||
                    (!input.All(char.IsLetterOrDigit) && !allowNullOrEmptyOutput));


            // checked if user want to cancel
            if (input.ToLower().Equals("c"))
            {
                return false;
            }

            return true;
        } // ReadUserInput(out string)


        /* ReadUserInput - decimal overload
         * Prompts the user to input a decimal,
         * Validates is user typed 'c' or 'C' to cancel operation
         * Parses and outputs the user input to out decimal variable  */
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

        } // ReadUserInput(out decimal)


        /* ReadUserInput - Integer overload
         * Prompts the user to input an integer,
         * Validates is user typed 'c' or 'C' to cancel operation
         * Parses and outputs the user input to out integer variable */
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

        } // ReadUserInput(out int)


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

            TextUI.ClearKeyboardBuffer();
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
                else if (char.IsLetterOrDigit(info.KeyChar) ||
                         char.IsPunctuation(info.KeyChar) ||
                         char.IsWhiteSpace(info.KeyChar))
                {
                    Console.Write(info.KeyChar);
                    chars.Add(info.KeyChar);
                }
            }
            return new string(chars.ToArray());

        } // EditReadLine(string)


        // Alows user to edit a given decimal value
        // Used to change the current value of a field
        private static decimal EditReadLine(decimal input)
        {
            string inputStr = input.ToString();
            inputStr = EditReadLine(inputStr);
            decimal.TryParse(inputStr, out decimal result);
            return result;
        } // EditReadLine(decimal)


        // Alows user to edit a given int value
        // Used to change the current value of a field
        private static int EditReadLine(int input)
        {
            string inputStr = input.ToString();
            inputStr = EditReadLine(inputStr);
            int.TryParse(inputStr, out int result);
            return result;

        } // EditReadLine(int)


        // Read the input from the user
        // Returns false is user typed 'C' to cancel
        // Returns true if/when item is found
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
                    Console.WriteLine("    > ERROR: Item not found. Please try again.");
                }
            }
            while (!string.IsNullOrEmpty(itemId) && !itemKeyExists);

            return true;

        } // FindItemByKey

        // Main Menu - Inventory application start
        internal void MainMenu(string shopName)
        {
            do
            {
                switch (TextUI.PrintMainMenu(shopName))
                {
                    case ConsoleKey.A:
                        AddShopItem(shopName);
                        break;
                    case ConsoleKey.R:
                        RemoveItem(shopName);
                        break;
                    case ConsoleKey.C:
                        ChangeItem(shopName);
                        break;
                    case ConsoleKey.L:
                        ListItems(shopName);
                        break;
                    case ConsoleKey.S:
                        SearchItem(shopName);
                        break;
                    case ConsoleKey.X:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option!");
                        Console.ReadLine();
                        break;
                }

            }
            while (true);
        } // MainMenu





        // Add new item to Shop list
        internal void AddShopItem(string shopName)
        {
            bool itemKeyExists;
            ShopItem newItem = new ShopItem();

            // Print Add item
            TextUI.PrintAddOption(shopName);

            // Input item ID - Validate if not null and not duplicate
            do
            {
                if (!ReadUserInput("    Product ID? ", out newItem.id, !AllowNullOrEmpty))
                {
                    return;
                }
                itemKeyExists = ContainsKey(newItem.id.ToLower().Trim());
                if (itemKeyExists)
                {
                    Console.WriteLine("    > ERROR: Item already exists. Use option \"Change Item\" to update the item.");
                }
            }
            while (!string.IsNullOrEmpty(newItem.id) && itemKeyExists);

            // Input each item property
            if (!ReadUserInput("    Description? ", out newItem.description, AllowNullOrEmpty)) { return; }
            if (!ReadUserInput("    Price? ", out newItem.price)) { return; }
            if (!ReadUserInput("    Cost? ", out newItem.cost)) { return; }
            if (!ReadUserInput("    Quantity? ", out newItem.quantity)) { return; }

            // Add item
            items.Add(newItem.id.ToLower().Trim(), newItem);

        } //AddShopItem(string shopName)


        // Finds and removes a Shop Item
        internal void RemoveItem(string shopName)
        {
            string removeItemId;

            // Print remove item 
            TextUI.PrintRemoveOption(shopName);

            // Find the item to remove
            if (!FindItemByKey(out removeItemId))
            {
                return;
            }

            // Get the item to remove 
            ShopItem removeItem = items[removeItemId];

            // RemoveItem item
            RemoveItem(removeItem);

        } // RemoveItem(string shopName)


        // Removes the provided Shop Item
        internal void RemoveItem(ShopItem removeItem)
        {
            // Print Item to remove
            Console.WriteLine("\n    Remove item:");
            PrintItemAsList(removeItem);

            // Confirmation before removing item
            ConsoleKey response = TextUI.ConfirmOperation("\n    Are you sure you want to PERMANENTLY DELETE this item? [y/n] ");

            // Remove item
            if (response == ConsoleKey.Y)
            {
                items.Remove(removeItem.id);
                Console.WriteLine($"\n    Item '{removeItem.id}' removed successfully.");
                TextUI.PrintPause();
            }
        } // RemoveItem(ShopItem removeItem)


        // Finds and changes a Shop Item
        internal void ChangeItem(string shopName)
        {
            string changeItemId;

            // Print Change Item
            TextUI.PrintChangeOption(shopName);

            // Find the item to change
            if (!FindItemByKey(out changeItemId))
            {
                return;
            }

            // Get the item to change 
            ShopItem changeItem = items[changeItemId];
            PrintItemAsList(changeItem);

            // Change the item
            ChangeItem(changeItem);

        } // ChangeItem(string shopName)


        // Changes the provided Shop item
        internal void ChangeItem(ShopItem changeItem)
        {
            // Displays the current value and allows user to change each property
            Console.WriteLine();
            Console.Write("    New Description: ");
            changeItem.description = EditReadLine(changeItem.description);
            Console.Write("    New Price: ");
            changeItem.price = EditReadLine(changeItem.price);
            Console.Write("    New Cost: ");
            changeItem.cost = EditReadLine(changeItem.cost);
            Console.Write("    New Quantity: ");
            changeItem.quantity = EditReadLine(changeItem.quantity);

            // Confirmation before changing item
            ConsoleKey response = TextUI.ConfirmOperation("\n    Are you sure you want to update this item? [y/n] ");

            // Update item
            if (response == ConsoleKey.Y)
            {
                items[changeItem.id] = changeItem;
                Console.WriteLine($"\n    Item '{changeItem.id}' updated successfully.");
                TextUI.PrintPause();
            }
        } // ChangeItem(ShopItem)


        // List all items in the class Inventory
        internal void ListItems(string shopName)
        {
            ListItems(shopName, items, "None");

        } // ListItems(string)


        // List all items from the provided Dictionary
        // Shows a menu of options to sort the list
        internal void ListItems(string shopName, Dictionary<string, ShopItem> items, string sortedBy)
        {
            Dictionary<string, ShopItem> sortedDict = new Dictionary<string, ShopItem>();

            // Print List
            TextUI.PrintListption(shopName);
            PrintItemsAsTable(items);
            
            // Show List sorting options
            switch (TextUI.PrintListMenu())
            {
                case ConsoleKey.I:
                    // Sort by ID
                    if (sortedBy == "ID")
                    {
                        sortedDict = (from entry in items orderby entry.Value.id descending select entry)
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        sortedBy = "None";
                    }
                    else
                    {
                        sortedDict = (from entry in items orderby entry.Value.id ascending select entry)
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        sortedBy = "ID";
                    }
                    break;
                case ConsoleKey.D:
                    // Sort by Description
                    if (sortedBy == "Desc")
                    {
                        sortedDict = (from entry in items orderby entry.Value.description descending select entry)
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        sortedBy = "None";
                    }
                    else
                    {
                        sortedDict = (from entry in items orderby entry.Value.description ascending select entry)
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        sortedBy = "Desc";
                    }
                    break;
                case ConsoleKey.P:
                    // Sort by Price
                    if (sortedBy == "Price")
                    {
                        sortedDict = (from entry in items orderby entry.Value.price descending select entry)
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        sortedBy = "None";
                    }
                    else
                    {
                        sortedDict = (from entry in items orderby entry.Value.price ascending select entry)
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        sortedBy = "Price";
                    }
                    break;
                case ConsoleKey.C:
                    // Sort by Cost
                    if (sortedBy == "Cost")
                    {
                        sortedDict = (from entry in items orderby entry.Value.cost descending select entry)
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        sortedBy = "None";
                    }
                    else
                    {
                        sortedDict = (from entry in items orderby entry.Value.cost ascending select entry)
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        sortedBy = "Cost";
                    }
                    break;
                case ConsoleKey.Q:
                    // Sort by Quantity
                    if (sortedBy == "Quant")
                    {
                        sortedDict = (from entry in items orderby entry.Value.quantity descending select entry)
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        sortedBy = "None";
                    }
                    else
                    {
                        sortedDict = (from entry in items orderby entry.Value.quantity ascending select entry)
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        sortedBy = "Quant";
                    }
                    break;
                case ConsoleKey.V:
                    // Sort by Value
                    if (sortedBy == "Value")
                    {
                        sortedDict = (from entry in items orderby entry.Value.value descending select entry)
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        sortedBy = "None";
                    }
                    else
                    {
                        sortedDict = (from entry in items orderby entry.Value.value ascending select entry)
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                        sortedBy = "Value";
                    }
                    break;
                case ConsoleKey.B:
                    return;
                default:
                    return;
            }
            // Call same function again with a sorted dictionary
            ListItems(shopName, sortedDict, sortedBy);

        } // ListItems(string, dictionary, string)


        // Search for items 
        // First tries get item by Key (case-sensitive)
        // if not found search by description (case-insensitive)
        // When the item is found by key, provides the option to change or remove the item
        internal void SearchItem(string shopName)
        {
            string searchString;
            bool singleItemFound = false;

            TextUI.PrintSearchOption(shopName);
            do
            {
                if (!ReadUserInput("    Product ID or Description? ", out searchString, !AllowNullOrEmpty))
                {
                    return;
                }
            }
            while (string.IsNullOrEmpty(searchString));

            ShopItem result;
            // Try get item by Key (case-sensitive), if not found search by description (case-insensitive)
            if (items.TryGetValue(searchString, out result))
            {
                // Show single item as a list of properties with options
                singleItemFound = true;
            }
            else
            {
                // Try searching any string (case-insensitive) in description 
                var results = items.Where(kvp => kvp.Value.description.IndexOf(searchString, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                           .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                if (results.Count > 0)
                {
                    if (results.Count == 1)
                    {
                        // Show single item as a list of properties with options
                        var first = results.OrderBy(kvp => kvp.Key).First();
                        result = first.Value;
                        singleItemFound = true;
                    }
                    else
                    {
                        // Show multiple items as a table of properties
                        Console.WriteLine();
                        PrintItemsAsTable(results);
                        TextUI.PrintPause();
                    }   
                }
                else
                {
                    Console.WriteLine("\n    Item not found!");
                    TextUI.PrintPause();
                }
            }

            if (singleItemFound)
            {
                // Show a single item as a list of properties
                PrintItemAsListWithValue(result);

                // Show options to manage item
                switch (TextUI.PrintSearchMenu())
                {
                    case ConsoleKey.R:
                        Console.WriteLine();
                        RemoveItem(result);
                        break;
                    case ConsoleKey.C:
                        Console.WriteLine();
                        ChangeItem(result);
                        break;
                    case ConsoleKey.B:
                        return;
                    default:
                        return;
                }
            }
        } // SearchItem
    } // Class Inventory
} // Namespace InventoryApp
