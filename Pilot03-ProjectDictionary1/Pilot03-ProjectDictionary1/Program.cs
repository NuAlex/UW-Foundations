using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pilot03_ProjectDictionary1.Inventory;

namespace Pilot03_ProjectDictionary1
{


    internal class Program
    {
        public void AddNewItem()
        {


        }


        static void Main(string[] args)
        {

            // Create Example object instance.
            var PetShop = new Inventory();

            /* TEST
            // Look up a value from the Dictionary field.
            // Console.WriteLine("RESULT: " + PetShop.GetValue("ABC123"));
            PetShop.Print(PetShop.GetValue("ABC123"));

            Console.WriteLine("Found Key \"ABC123\": {0}" , PetShop.ContainsKey("ABC123"));
            Console.WriteLine("Found Key \"ABC123\": {0}", PetShop.ContainsKey("BC123"));
     

            PetShop.ContainsKey("QWE");
            Console.ReadLine();
            */


            // BEGIN
            do
            {
                switch (TextUI.DisplayMainMenu())
                {
                    case 0:
                        Console.WriteLine("Exit!");
                        return;
                    case 1:
                        TextUI.PrintTitle("PET SHOP - LOVELY PUPPIES");
                        PetShop.AddShopItem();
                        break;
                    case 2:
                        Console.WriteLine("case2");
                        break;
                    case 3:
                        Console.WriteLine("case3");
                        break;
                    case 4:
                        TextUI.PrintTitle("PET SHOP - LOVELY PUPPIES");
                        PetShop.PrintAllItems();
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
            while (true);

            /*
            Console.WriteLine("Window size = {0} x {1}", Console.WindowWidth, Console.WindowHeight);
            Console.WriteLine("Encoding CodePage {0} / {1}", Console.OutputEncoding.CodePage, Console.OutputEncoding.WindowsCodePage);

            
            // https://learn.microsoft.com/en-us/dotnet/api/system.console?view=net-7.0
            uint rangeStart = 0;
            uint rangeEnd = 0;
            bool setOutputEncodingToUnicode = true;

            // Get the current encoding so we can restore it.
            Encoding originalOutputEncoding = Console.OutputEncoding;
            try
            {
                rangeStart = uint.Parse("2500", NumberStyles.HexNumber);
                rangeEnd = uint.Parse("2600", NumberStyles.HexNumber);

                if (setOutputEncodingToUnicode)
                {
                    // This won't work before .NET Framework 4.5.
                    try
                    {
                        // Set encoding using endianness of this system.
                        // We're interested in displaying individual Char objects, so
                        // we don't want a Unicode BOM or exceptions to be thrown on
                        // invalid Char values.
                        Console.OutputEncoding = new UnicodeEncoding(!BitConverter.IsLittleEndian, false);
                        Console.WriteLine("\nOutput encoding set to UTF-16");
                    }
                    catch (IOException)
                    {
                        Console.OutputEncoding = new UTF8Encoding();
                        Console.WriteLine("Output encoding set to UTF-8");
                    }
                }
                else
                {
                    Console.WriteLine("The console encoding is {0} (code page {1})",
                                      Console.OutputEncoding.EncodingName,
                                      Console.OutputEncoding.CodePage);
                }
                TextUI.DisplayRange(rangeStart, rangeEnd);
            }
            catch (ArgumentException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                // Restore console environment.
                Console.OutputEncoding = originalOutputEncoding;
            }
            Console.ReadLine();

            

            /*
            Dictionary<string, ShopItem> shopItems = new Dictionary<string, ShopItem>();
            //shopItems = shopItems.ShopInventorySamples();

            ShopItem shopItem1 = new ShopItem("ABC121", "Dog1", (decimal)123.99, (decimal)90.10, 1, 2);
            ShopItem shopItem2 = new ShopItem("ABC122", "Dog2", (decimal)123.99, (decimal)90.10, 1, 2);
            ShopItem shopItem3 = new ShopItem("ABC123", "Dog3", (decimal)123.99, (decimal)90.10, 1, 2);

            shopItems.Add(shopItem1.id, shopItem1);
            shopItems.Add(shopItem2.id, shopItem2);
            shopItems.Add(shopItem3.id, shopItem3);


            ShopItem s;
            // Tries to get the Value for the provided Key
            if (shopItems.TryGetValue("ABC123", out  s))
            {
                Console.WriteLine("Found: " + s.id + ": " + s.description + " | " + shopItems.Count);
            }
            Console.WriteLine("Contains s? " + shopItems.ContainsValue(s).ToString());

            Console.WriteLine("Contains key 'ABC123'? " + shopItems.ContainsKey("ABC123"));
            */

            Console.ReadLine();
            Console.Clear();
        }
    }
}
