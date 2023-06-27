namespace InventoryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var PetShop = new PetShop();
            PetShop.InitSampleData();
            PetShop.StartApp();
        
        } // Main
    } // Class Program
} // Namespace PetShop
