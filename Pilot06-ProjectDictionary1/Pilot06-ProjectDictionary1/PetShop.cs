using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pilot06_ProjectDictionary1.Inventory;
using static System.Net.Mime.MediaTypeNames;

namespace Pilot06_ProjectDictionary1
{
    internal class PetShop
    {

        internal static void NewMenu()
        {
            Dictionary<ConsoleKey, string> menu = new Dictionary<ConsoleKey, string>();
            menu.Add(ConsoleKey.A, "(A)dd Item");
            menu.Add(ConsoleKey.R, "(R)emove Item");
            menu.Add(ConsoleKey.C, "(C)hange Item");

            foreach (var m in menu)
            {
                Console.WriteLine(m.Value);
            }

            ConsoleKeyInfo info;
            //KeyValuePair<ConsoleKey, string> keyValuePair = new KeyValuePair<ConsoleKey, string>();
            string option;
            do
            {
                info = Console.ReadKey(true);
                if (menu.TryGetValue(info.Key, out option))
                {
                    Console.WriteLine(option);
                }


            }
            while (true);
        }


    }
}
