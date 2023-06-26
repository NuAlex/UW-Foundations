using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Dictionary<string, ShopItem> items = new Dictionary<string, ShopItem>();
        /*
        public Dictionary<string, ShopItem> items = new Dictionary<string, ShopItem>()
        {
            {"abc121", new ShopItem {id = "ABC121", description = "Dog1", price = 123.99m, cost = 90.10m, quantity = 1} },
            {"abc123", new ShopItem {id = "ABC123", description = "Dog3", price = 123.99m, cost = 90.10m, quantity = 3} },
            {"abc122", new ShopItem {id = "ABC122", description = "Dog2", price = 123.99m, cost = 90.10m, quantity = 2} }
        };
        */

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
        public Dictionary<string, ShopItem> Find(string searchString)
        {

            List<string> WordList = new List<string>();
            string[] wordsArray = { "Portuguese", "qwe", "Rottweiler" };
            WordList.AddRange(wordsArray);

            var Words2 = items.Where(kvp => WordList.Contains(kvp.Value.description)) // case-sensitive , word match
                     .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            //items.Add(Words2.Keys, Words2.Values);
            //items.Append();

            PrintItems(Words2);

            Console.WriteLine($"Search {searchString}:");
            //var results = items.Where(kvp => searchString.Contains(kvp.Value.description)) // case-sensitive , word match
            var results = items.Where(kvp => kvp.Value.description.Contains(searchString)) // case-sensitive , word match
                     .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            PrintItems(results);

            // Try get by key
            searchString = "gold";
            Console.WriteLine($"Search by Key {searchString}:");
            ShopItem result;
            if (items.TryGetValue(searchString, out result))
            {
                Console.WriteLine($"Found 1 result: {result.description}");
            }

            // Try get by key
            searchString = "York";
            Console.WriteLine($"Search by Key {searchString}:");
            if (items.TryGetValue(searchString, out result))
            {
                Console.WriteLine($"Found 1 result: {result.description}");
            }


            searchString = "water";
            Console.WriteLine($"Search {searchString}:");

            //results = items.Where(kvp => searchString.IndexOfAny(kvp.Value.description, 0, StringComparison.OrdinalIgnoreCase)) // case-sensitive , word match
            //results = items.Where(kvp => kvp.Value.description.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)) // .net5
            //            .IndexOf("string", 0, StringComparison.OrdinalIgnoreCase) != -1)
            results = items.Where(kvp => kvp.Value.description.IndexOf(searchString, 0, StringComparison.CurrentCultureIgnoreCase) != -1) 
                       .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            PrintItems(results);

            searchString = "labrador";
            Console.WriteLine($"Search {searchString}:");
            results = items.Where(kvp => kvp.Value.description.IndexOf(searchString, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                       .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            PrintItems(results);

            return results;
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
            PetShop.InitSampleData();

            Inventory results = new Inventory();
            results.items = PetShop.Find("Beagle");

            //results.PrintItems();

            //Inventory results2 = new Inventory();
            //string searchString = "abc";
            /*
            results2.items = PetShop.items.Where(kvp =>
            
            var Words2 = items.Where(kvp => WordList.Contains(kvp.Value.description))
         .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            */

            Console.ReadLine();
        }
    }
}
