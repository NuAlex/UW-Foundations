using System;
using System.Collections.Generic;

struct Contact
{
    public String Name;
    public String PhoneNumber;
}
internal class Program
{
    static void Main()
    {
        // TODO: Create a list of Contact
        var contacts = new List<Contact>();

        // TODO: Add contacts to the list
        contacts.Add(new Contact { Name = "Nuno", PhoneNumber = "4255559999"});
        contacts.Add(new Contact { Name = "Alex", PhoneNumber = "4250001234"});

        // TODO: Display the Name and PhoneNumber of all the contacts
        foreach (Contact c in contacts)
        {
            Console.WriteLine("{0}: {1}", c.Name, c.PhoneNumber);
        }

        Console.ReadLine();
    }
}
