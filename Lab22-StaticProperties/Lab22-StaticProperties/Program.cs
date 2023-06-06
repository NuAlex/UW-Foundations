/*
 * Modify the Static Fields lab to create a read-only static property for CurrentNextContactId. It would simply return the current value of nextContactId.
 * A read-only property only has get and not set.
 * Use the following code for your Main. Use the struct Contact from your Static Fields lab with the new static property CurrentNextContactId.
 */ 

using System;

internal class Program
{
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
        private static int nextContactId = 100;

        // TODO: Copy your code from Static Fields lab here
        // TODO: Add static property CurrenctNextId
        public static int CurrentNextContactId
        {
            get => nextContactId;
        }
    }
    static void Main()
    {
        Console.WriteLine("CurrentNextContactId = {0} should be 100", Contact.CurrentNextContactId);

        var contact = new Contact("mike", "111-222-3333");

        // TODO: Why does is not compile? What does the compiler say?
        // >> Static member 'member' cannot be accessed with an instance reference
        //Console.WriteLine("CurrentNextContactId = {0} should be 101", contact.CurrentNextContactId);
        // Correction:
        Console.WriteLine("CurrentNextContactId = {0} should be 101", Contact.CurrentNextContactId);

        var contact2 = new Contact("steve", "222-333-4444");

        // TODO: Why does is not compile? What does the compiler say?
        // >> Static member 'member' cannot be accessed with an instance reference
        //Console.WriteLine("CurrentNextContactId = {0} should be 102", contact2.CurrentNextContactId);
        // Correction:
        Console.WriteLine("CurrentNextContactId = {0} should be 102", Contact.CurrentNextContactId);

        Console.ReadLine();
    }
}
