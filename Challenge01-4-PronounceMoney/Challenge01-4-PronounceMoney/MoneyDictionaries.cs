using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge01_4_PronounceMoney
{
    internal class MoneyDictionaries
    {
        public static Dictionary<string, string> TranslateNumbers = new Dictionary<string, string>();

        public void InitiateDictionaly()
        {
            TranslateNumbers.Add("1", "one");
        }
        
    }
}
