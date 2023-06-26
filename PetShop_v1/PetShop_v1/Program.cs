namespace PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var PetShop = new PetShop("PET SHOP KIDS - LOVELY PUPPIES");
            PetShop.InitSampleData();
            PetShop.MainMenu();
        }
    }
}
