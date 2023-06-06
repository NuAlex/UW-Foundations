using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool ContainsKey(string key)
        {
            return items.ContainsKey(key);
        }
        public void Print(ShopItem item)
        {
            Console.WriteLine(item.id + " " + item.description);
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
