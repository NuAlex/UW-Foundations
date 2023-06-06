using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot03_ProjectDictionary1
{
    class ShopItem
    {

        public string id;
        public string description;
        decimal price;
        decimal cost;
        decimal value;
        int quantity;

        public ShopItem(string id, string description, decimal price, decimal cost, decimal value, int quantity)
        {
            this.id = id;
            this.description = description;


        }

        /*
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


    internal class Inventory
    {
    }
}
