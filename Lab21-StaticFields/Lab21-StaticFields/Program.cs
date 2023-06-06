// Here is a very common usage case of static fields.
// You could use some kind of variable to keep track of the next contact id or you could put it in the class itself.
using System;

struct Contact
{
    public int ContactId;
    public String Name;
    public String PhoneNumber;
    
    public Contact(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        ContactId = nextContactId++;
    }

    // TODO: Create static nextContactId
    private static int nextContactId = 100;

}

internal class Program
{
    static void Main(string[] args)
    {
        var contact = new Contact("mike", "111-222-3333");

        Console.WriteLine("ContactId = {0} should be 100", contact.ContactId);

        var contact2 = new Contact("steve", "222-333-4444");

        Console.WriteLine("ContactId = {0} should be 101", contact2.ContactId);

        Console.ReadLine();
    }
}
