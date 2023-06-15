using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Pilot05_DictionaryFind
{

    class Inventory
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
        
        // Data
        public Dictionary<string, ShopItem> items = new Dictionary<string, ShopItem>()
        {
            {"abc121", new ShopItem {id = "ABC121", description = "Dog1", price = 123.99m, cost = 90.10m, quantity = 1} },
            {"abc123", new ShopItem {id = "ABC123", description = "Dog3", price = 123.99m, cost = 90.10m, quantity = 3} },
            {"abc122", new ShopItem {id = "ABC122", description = "Dog2", price = 123.99m, cost = 90.10m, quantity = 2} }
        };

        public Dictionary<string, ShopItem> Find(string description)
        {

            List<string> WordList = new List<string>();
            string[] wordsArray = { "abc", "qwe", "Dog1" };
            WordList.AddRange(wordsArray);

            var Words2 = items.Where(kvp => WordList.Contains(kvp.Value.description))
                     .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            //items.Add(Words2.Keys, Words2.Values);
            //items.Append();

            PrintItems(Words2);

            return Words2;
        }

        public void PrintItems(Dictionary<string, ShopItem> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine($"Key {item.Key} | Description {item.Value.description}");
            }
        }

        public void PrintItems()
        {
            PrintItems(items);
        }




    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string,string> Data = new Dictionary<string,string>();

            Data.Add("1", "abc");
            Data.Add("2", "xyz");

            List<string> WordList = new List<string>();
            string[] wordsArray = {"abc","qwe","Dog1"};
            WordList.AddRange(wordsArray);

            var Words = Data.Where(kvp => WordList.Contains(kvp.Value))
                  .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);


            Inventory PetShop = new Inventory();

            Inventory results = new Inventory();
            results.items = PetShop.Find("Dog1");

            PetShop.PrintItems();




            Console.WriteLine("end");
        }
    }
}
