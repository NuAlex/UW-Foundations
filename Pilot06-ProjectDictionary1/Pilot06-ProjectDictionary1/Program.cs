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
            var PetShop = new PetShop("PET SHOP KIDS - LOVELY PUPPIES");
            PetShop.InitSampleData();
            PetShop.MainMenu();
        }
    }
}
