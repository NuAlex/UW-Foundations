using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge10_ContactsList
{
    internal class Program
    {
        struct Contact
        {
            public string Name;
            public string PhoneNumber;
        }

        static void Main(string[] args)
        {
            var contacts = new List<Contact>();

            // TODO: Create a bunch of contacts with phone numbers
            Contact contact1 = new Contact();
            contact1.Name = "Nuno";
            contact1.PhoneNumber = "4259999999";
            contacts.Add(contact1);
            
            Contact contact2 = new Contact();
            contact1.Name = "Miguel";
            contact1.PhoneNumber = "4250101010";
            contacts.Add(contact2);
            
            Contact contact3 = new Contact();
            contact1.Name = "Alex";
            contact1.PhoneNumber = "425000000";
            contacts.Add(contact3);

            contacts.Sort(); // causes "Failed to compare two elements in the array." exception
            var contactsSorted = contacts.AsEnumerable()
                .Select(row => row.Name)
               //.Distinct()
               .OrderBy(x => x)
               .ToList();
            contactsSorted.Sort();


            // TODO: Display contacts
            foreach (Contact contact in contacts)
            {
                Console.WriteLine("{0}: (1}", contact.Name, contact.PhoneNumber);
            }

            foreach (Contact contact in contactsSorted)
            {
                Console.WriteLine("{0}: (1}", contact.Name, contact.PhoneNumber);
            }

            Console.ReadLine();
        }
    }
}
