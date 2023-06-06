using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot03_ProjectDictionary1
{

    public AddNewItem()
    {


    }

    internal class Program
    {


        static void Main(string[] args)
        {

            Dictionary<string, ShopItem> shopItems = new Dictionary<string, ShopItem>();
            //shopItems = shopItems.ShopInventorySamples();

            ShopItem shopItem1 = new ShopItem("ABC121", "Dog1", (decimal)123.99, (decimal)90.10, 1, 2);
            ShopItem shopItem2 = new ShopItem("ABC122", "Dog2", (decimal)123.99, (decimal)90.10, 1, 2);
            ShopItem shopItem3 = new ShopItem("ABC123", "Dog3", (decimal)123.99, (decimal)90.10, 1, 2);

            shopItems.Add(shopItem1.id, shopItem1);
            shopItems.Add(shopItem2.id, shopItem2);
            shopItems.Add(shopItem3.id, shopItem3);


            ShopItem s;
            if (shopItems.TryGetValue("ABC123", out  s))
            {
                Console.WriteLine(s.id + ": " + s.description + " | " + shopItems.Count);
            }
            Console.WriteLine("Contains s? " + shopItems.ContainsValue(s).ToString());

            Console.ReadLine();
        }
    }
}
