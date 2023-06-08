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
            {"ABC121", new ShopItem {id = "ABC121", description = "Dog1", price = 123.99m, cost = 90.10m, quantity = 1} },
            {"ABC123", new ShopItem {id = "ABC123", description = "Dog3", price = 123.99m, cost = 90.10m, quantity = 3} },
            {"ABC122", new ShopItem {id = "ABC122", description = "Dog2", price = 123.99m, cost = 90.10m, quantity = 2} }
        };

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
        public bool ContainsKey(string key)
        {
            return items.ContainsKey(key);
        }


        // Print a Shop Item
        public void Print(ShopItem item)
        {
            Console.WriteLine(item.id + " " + item.description);
        }

        public bool ReadUserInput(string prompt, out string input) 
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            
            // checked if user want to cancel
            if (input.ToLower().Equals("c"))
            {
                return false;
            }
            return true; 
        }

        public bool ReadUserInput(string prompt, out decimal inputDecimal)
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

        public bool ReadUserInput(string prompt, out int inputInt)
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


        public void AddShopItem()
        {
            Console.WriteLine("    New Shop Item - Type \"c\" to cancel.\n");

            string input;
            bool itemKeyExists;
            ShopItem newItem = new ShopItem();
            
            // Input item ID - Validate if not null and not duplicate
            do
            {

                if (!ReadUserInput("    Product ID? ", out newItem.id)) { return; }
                itemKeyExists = ContainsKey(newItem.id.ToLower());
                if (itemKeyExists)
                {
                    Console.WriteLine("    ERROR: Item already exists. Use option \"Change Item\" to update the item.");
                }
            }
            while (!string.IsNullOrEmpty(newItem.id) && itemKeyExists);

            if (!ReadUserInput("    Description? ", out newItem.description))   { return; }
            if (!ReadUserInput("    Price? ", out newItem.price))               { return; }
            if (!ReadUserInput("    Cost? ", out newItem.cost))                 { return; }
            if (!ReadUserInput("    Quantity? ", out newItem.quantity))         { return; }

            items.Add(newItem.id.ToLower(), newItem);
        }

        // Show all items on the screen
        public void PrintAllItems()
        {
            //Console.WriteLine("{0,10} | {1,20} | {2,10} | {3,10} | {4,10}",
            Console.WriteLine("{0,3} | {1,10} | {2,-40} | {3,20:C} | {4,20:C} | {5,20} | ",
                " ",
                "Id",
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
                    item.Value.price.ToString(), 
                    item.Value.cost.ToString(), 
                    item.Value.quantity.ToString());
                /*
                Console.WriteLine("{0,-5} | {1,-20} | {2,10:C}",
                    item.Value.id,
                    item.Value.description,
                    item.Value.price.ToString());
                */
            }
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
