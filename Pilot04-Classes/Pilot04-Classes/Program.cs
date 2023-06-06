using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot04_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create new object instances
            Book book1 = new Book("War and Peace", "Tolstoy", 800);
            Book book2 = new Book("The Grapes of Wrath", "Steinbeck", 400);

            // Call method
            Console.WriteLine(book1.GetDescription());
            Console.WriteLine(book2.GetDescription());

            book1.Name = "lala1";
            book1.Author = "lala2";

            Console.WriteLine(book1.GetDescription());
            Console.WriteLine(book1.Name);

            Console.WriteLine(book1.Description);
            

            book2.Price = 12.34m; // 'm' is for decimal values
            book2.ISBN = "110140449876";


            Console.WriteLine(book2.Description);
            Console.WriteLine(book2.ToString());
            Console.WriteLine(book2.ToString('B'));
            Console.WriteLine(book2.ToString('F'));

            Console.ReadLine();
        }
    }
}
