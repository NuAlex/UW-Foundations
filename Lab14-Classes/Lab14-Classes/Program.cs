// Lab 14 - Classes
// Define the Contact class
using System;

namespace Lab14_Classes
{
    class Contact
    {
        /* Without Data Hiring - bad practice
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        */

        // Best Practice
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName { get { return firstName; } set {  firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public int Age { get { return age; } set { age = value; } }

        public string GetFullName()
        {
            string fullName = string.Format("{0} {1}", FirstName, LastName);
            return fullName;
   
        }
    }

    internal class Program
    {
        static void Main()
        {

            Contact contact = new Contact
            {
                FirstName = "Nuno",
                LastName = "Alex",
                Age = 47
            };

            /* Same as:
            Contact contact = new Contact();

            contact.FirstName = "Nuno";
            contact.LastName = "Alex";
            contact.Age = 47;
            */

            // GetFullName() returns "FirstName LastName"
            Console.WriteLine("Name: {0} \nAge: {1}", contact.GetFullName(), contact.Age);
            Console.ReadLine();

        }
    }
}
