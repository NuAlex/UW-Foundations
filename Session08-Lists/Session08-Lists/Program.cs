/*
 * Lists
Arrays are useful in creating collections of fixed-sized content. The problem arises when you need to add or delete items from the array. Resizing an array is not difficult but it can be tedious. Arrays have a Length property to indicate it's capacity.

An ArrayList is an early class of .NET. ArrayLists allow you to add, find, and delete items easily. The biggest problem is that ArrayList is a collection of objects so you have to cast the object to the actual type. The ArrayList has a Capacity to indicate how many slots are available for use and a Count property to indicate how many slots are in use.

The List class is a newer class of .NET. It is part of the generics section. Generics are a topic all by itself. But basically, a generic class (such as List) keeps track of the type of objects that it contains. List works very much like ArrayList except that no casting is necessary. The List has a Capacity to indicate how many slots are available for use and a Count property to indicate how many slots are in use.
*/

using System;
using System.Collections.Generic;
using System.Collections;

struct Pet
{
    public string Name;
    public int Age;
}

internal class Program
{
    static void Main()
    {
        // ArrayList is part of System.Collections
        // This is an old part of .NET
        // Create an ArrayList of objects
        var oldPets = new ArrayList();

        // Notice the new way of instantiating a Pet by using field names
        oldPets.Add(new Pet { Name = "Spot", Age = 2 });
        oldPets.Add(new Pet { Name = "Missy", Age = 1 });

        // You have to unbox oldPets because it returns an object
        var oldPet = (Pet)oldPets[0];

        // If you use "foreach (var pet in oldPets)", pet is an object
        // If you use "foreach (Pet pet in oldPets)", .NET will cast the object to Pet
        foreach (Pet pet in oldPets)
        {
            Console.WriteLine("Old Name: {0} Age: {1}", pet.Name, pet.Age);
        }

        // List is part of System.Collections.Generic
        // This is the new part of .NET
        // var pets = new List of type Pet. The <Pet> denotes the type of list
        var pets = new List<Pet>();

        pets.Add(new Pet { Name = "Rover", Age = 3 });
        pets.Add(new Pet { Name = "Tinkerbell", Age = 4 });

        // No need to unbox pets because it's a List of Pet.
        var newPet = pets[1];

        // No need to do "foreach (Pet pet in pets) because pets is a List of Pet.
        foreach (var pet in pets)
        {
            Console.WriteLine("New Name: {0} Age: {1}", pet.Name, pet.Age);
        }

        Console.ReadLine();
    }
}
