using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Pilot01_Collections
{
    internal class Program
    {
        static void Main()
        {

            // Dictionary map keys to values.
            Dictionary<string, double> dic = new Dictionary<string, double>();

            dic.Add("one", 1);
            dic.Add("ten", 10);
            dic.Add("hundred", 100);
            dic.Add("thousand", 1000);

            foreach (var d in dic)
            {
                //Console.WriteLine(d);
                Console.WriteLine("hashtable Key {0} | Value {1}", d.Key, d.Value);
            }
            // Set Values
            //dic["hundred"] = 100;
            // This method was introduced in .NET Core 2.0 and .NET Standard 2.1, so you need your target framework to be at least that
            //bool added = dic.TryAdd("million", 1000000);


            Console.WriteLine("Key value for 'hundred': {0}", dic["hundred"]);

            Console.WriteLine("Contains Key 'ten': {0}", dic.ContainsKey("ten"));
            Console.WriteLine("Contains Value '10': {0}", dic.ContainsValue(10));
            Console.WriteLine("Dic Count: {0}", dic.Count);
            var myKey = dic.FirstOrDefault(x => x.Value == 1000).Key;
            Console.WriteLine("Get Key from Value '1000' : {0}", myKey);
            var findValue = 2;
            var missingKey = dic.FirstOrDefault(x => x.Value == findValue).Key;
            Console.WriteLine("Get Key from Value '2' (non-existing): {0}", missingKey);
            if (null == missingKey)
            {
                Console.WriteLine("The value {0} is not found in Dictionary!", findValue);
            }

            //
            OrderedDictionary oDic = new OrderedDictionary();
            oDic.Add("one", 1);
            oDic.Add("two", 2);
            //oDic.Add("tree", 2); // causes an exception
            oDic.Add("tree", 3);

            foreach (DictionaryEntry de in oDic)
            {
                Console.Write(de.Key);
                Console.Write(" | ");
                Console.WriteLine(de.Value);
                
            }
            Console.WriteLine("Key value for 'two': {0}", oDic["hundred"]);
                        
            Console.WriteLine("Contains Key 'ten': {0}", oDic.Contains("ten"));
            Console.WriteLine("Contains Value '10': {0}", oDic.Contains(10));
            Console.WriteLine("oDic Count: {0}", oDic.Count);

            /* cannot use FirstOrDefault
            var myKey2 = oDic.FirstOrDefault(x => x.Value == 1000).Key;
            Console.WriteLine("Get Key from Value '1000' : {0}", myKey2);

            var findValue2 = 2;
            var missingKey2 = oDic.FirstOrDefault(x => x.Value == findValue2).Key;
            Console.WriteLine("Get Key from Value '2' (non-existing): {0}", missingKey2);
            if (null == missingKey2)
            {
                Console.WriteLine("The value {0} is not found in oDictionary!", findValue2);
            }
            */
            Console.ReadLine();

        }
    }
}
