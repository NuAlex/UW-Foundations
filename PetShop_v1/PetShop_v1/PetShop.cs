using System;
using System.Collections.Generic;

namespace PetShop
{
    internal class PetShop : Inventory
    {
        // Variables
        public readonly string ShopName;

        public PetShop(string Name)
        {
            ShopName = Name;
        }

        // Sample data to test the program
        internal void InitSampleData()
        {
            items.Add("pood", new ShopItem { id = "pood", description = "Poodle", price = 1599.99m, cost = 1090.10m, quantity = 3 });
            items.Add("boxe", new ShopItem { id = "boxe", description = "Boxer", price = 1129.99m, cost = 910.10m, quantity = 2 });
            items.Add("york", new ShopItem { id = "york", description = "Yorkshire", price = 1169.99m, cost = 809.88m, quantity = 4 });
            items.Add("bull", new ShopItem { id = "bull", description = "Bulldog", price = 4489.99m, cost = 4128.14m, quantity = 2 });
            items.Add("beag", new ShopItem { id = "beag", description = "Beagle", price = 4799.99m, cost = 4436.87m, quantity = 1 });
            items.Add("alab", new ShopItem { id = "alab", description = "American Labrador", price = 4639.99m, cost = 4275.13m, quantity = 2 });
            items.Add("elab", new ShopItem { id = "elab", description = "English Labrador", price = 4639.99m, cost = 4275.13m, quantity = 2 });
            items.Add("port", new ShopItem { id = "port", description = "Portuguese Water Dog", price = 4269.99m, cost = 3907.88m, quantity = 1 });
            items.Add("malt", new ShopItem { id = "malt", description = "Maltese", price = 3749.99m, cost = 3381.84m, quantity = 5 });
            items.Add("gold", new ShopItem { id = "gold", description = "Golden Retriever", price = 2969.99m, cost = 2602.3m, quantity = 2 });
            items.Add("rott", new ShopItem { id = "rott", description = "Rottweiler", price = 4329.99m, cost = 3967.2m, quantity = 1 });
        }

        // Begin PetShot
        internal void MainMenu()
        {
            do
            {
                switch (TextUI.PrintMainMenu(ShopName))
                {
                    case ConsoleKey.A:
                        AddShopItem(ShopName);
                        break;
                    case ConsoleKey.R:
                        RemoveItem(ShopName);
                        break;
                    case ConsoleKey.C:
                        ChangeItem(ShopName);
                        break;
                    case ConsoleKey.L:
                        ListItems(ShopName);
                        break;
                    case ConsoleKey.S:
                        SearchItem(ShopName);
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
        }
    }
}
