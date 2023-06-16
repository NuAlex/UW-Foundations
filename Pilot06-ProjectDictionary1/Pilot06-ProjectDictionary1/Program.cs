using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot06_ProjectDictionary1
{
    internal class Program
    {
        static void Main()
        {
            var PetShop = new Inventory("PET SHOP KIDS - LOVELY PUPPIES");

            // BEGIN
            do
            {
                TextUI.PrintTitle(PetShop.ShopName);
                switch (TextUI.DisplayMainMenu())
                {
                    case ConsoleKey.A:
                        TextUI.PrintTitle(PetShop.ShopName);
                        PetShop.AddShopItem();
                        break;
                    case ConsoleKey.R:
                        TextUI.PrintTitle(PetShop.ShopName);
                        PetShop.RemoveItem();
                        break;
                    case ConsoleKey.C:
                        TextUI.PrintTitle(PetShop.ShopName);
                        PetShop.ChangeItem();
                        break;
                    case ConsoleKey.L:
                        TextUI.PrintTitle(PetShop.ShopName);
                        PetShop.PrintItemsAsTable();
                        break;
                    case ConsoleKey.S:
                        TextUI.PrintTitle(PetShop.ShopName);
                        Console.WriteLine("Not implemented!");
                        Console.ReadLine();
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
