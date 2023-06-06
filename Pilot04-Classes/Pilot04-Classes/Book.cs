using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot04_Classes
{
    
    // SWITCH from INTERNAL (default) to PUBLIC CLASS
    public class Book
    {
        // --- class member variables or "fields"
        string _name;
        string _author;
        int _pagecount;

        // --- properties of the class (type "prop" + Tab)
        public string Name { 
            get 
            { 
                return _name; 
            } 
            set 
            { 
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be blank!");
                }
                _name = value; 
            } 
        }
        //shorthand way using => operator to create "expression-bobied" properties
        public string Author {
            get => _author;
            set => _author = value; 
        }
        public int PageCount { get; set; }

        // Computed property
        public string Description
        {
            get => $"{_name} by {_author}, {_pagecount} pages (ISBN: {ISBN}) = ${Price}";
        }

        // Override the ToString method
        // Every class inherits from Object, which means that every class inherits the ToString() method.
        public override string ToString()
        {
            return $"{_name} by {_author}";
        }

        // Overloaded (not overrided) method
        public string ToString(char format)
        {
            if (format == 'B')
            {
                return $"{_name}: {_author}";
            }
            if (format == 'F')
            {
                return $"{_name} by {_author}, {_pagecount} pages (ISBN: {ISBN}) = ${Price}";
            }
            return ToString();
        }

        // Auto-generated property that holds data (since there's no backing field)
        public string ISBN { get; set; }
        public decimal Price { get; set; }

        // --- constructors
        public Book(string Name, string Author, int Pages)
        {
            _name = Name;
            _author = Author;
            _pagecount = Pages;
        }

        // --- methods
        public string GetDescription()
        {
            return $"{_name} by {_author}";
        }


    }
}
