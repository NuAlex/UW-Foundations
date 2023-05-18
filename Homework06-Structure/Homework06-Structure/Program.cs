using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Homework06_Structure
{
    public struct Pet
    {
        public string Name;
        public string TypeOfPet;
    }

    internal class Program
    {
        public static bool PetsExist(int count)
        {
            if (count == 0)
            {
                Console.WriteLine("No pets!");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void ListPets(Pet[] pets, int petsCount)
        {
            if (petsCount > 0)
            {
                Console.WriteLine("#. {0,-10} {1}", "NAME", "TYPE");

                for (int index = 0; index < pets.Count(); index++)
                {
                    if (!String.IsNullOrEmpty(pets[index].Name))
                    {
                        Console.WriteLine("{0}. {1,-10} {2}", index + 1, pets[index].Name, pets[index].TypeOfPet);
                    }
                }
            }
        }


        public static int SelectPet(Pet[] pets, int petCount, string action)
        {
            // Select the pet to change or update
            var petInput = "";
            var petIndex = -1;
            do
            {
                Console.Write("Which pet to {0} (1-{1}) or 0 to cancel? ", action, petCount);
                petInput = Console.ReadLine();
                petIndex = int.Parse(petInput);
            }
            while (petIndex < 0 && petIndex > petCount);
            return petIndex;
        }


        static void Main()
        {
            var numberOfPets = 0;
            var maxPetsCount = 10;
            var pets = new Pet[maxPetsCount];
            var newPet = new Pet
            {
                // Test
                Name = "Snowflake",
                TypeOfPet = "Maltese Dog"
            };
            pets[numberOfPets] = newPet;
            numberOfPets++;

            while (true)
            {
                Console.Write("(A)dd  |  (C)hange  |  (D)elete  |  (L)ist pets  |  e(X)it: ");
                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "A":
                    case "a":
                        {
                            if (numberOfPets == maxPetsCount)
                            {
                                Console.WriteLine("You've reach the maximum limit of {0} pets. \n" +
                                    "Please delete some pets or pay your developer to add more capacity.", numberOfPets);
                            }
                            else
                            {
                                // A pet Name is mandatory
                                var name = "";
                                do
                                {
                                    Console.Write("Name: ");
                                    name = Console.ReadLine();
                                    if (String.IsNullOrEmpty(name))
                                    {
                                        Console.WriteLine("Invalid Name!");
                                    }
                                } 
                                while (String.IsNullOrEmpty(name));
                                
                                Console.Write("Type of pet: ");
                                var typeOfPet = Console.ReadLine();

                                newPet.Name = name;
                                newPet.TypeOfPet = typeOfPet;

                                pets[numberOfPets] = newPet;
                                numberOfPets++;
                            }
                            break;
                        }

                    case "C":
                    case "c":
                        {
                            if (PetsExist(numberOfPets))
                            {
                                ListPets(pets, numberOfPets);

                                var petIndex = SelectPet(pets, numberOfPets, "change");

                                if (petIndex > 0)
                                {
                                    // decrementing 1 to match the user input with array index
                                    petIndex--;
                                    var petInput = "";
                                    Console.Write("(Press <Enter> to keep '{0}') New Name? ", pets[petIndex].Name);
                                    petInput = Console.ReadLine();
                                    if (!String.IsNullOrEmpty(petInput))
                                    {
                                        pets[petIndex].Name = petInput;
                                    }

                                    Console.Write("(Press <Enter> to keep '{0}') New Type of Pet? ", pets[petIndex].TypeOfPet);
                                    petInput = Console.ReadLine();
                                    pets[petIndex].TypeOfPet = petInput;
                                }
                            }
                            break;
                        }

                    case "D":
                    case "d":
                        {
                            if (PetsExist(numberOfPets))
                            {
                                ListPets(pets, numberOfPets);

                                var petIndex = SelectPet(pets, numberOfPets, "remove");

                                /*
                                Console.Write("Which pet to remove (1-{0})? ", numberOfPets);

                                var petInput = Console.ReadLine();
                                var petIndex = int.Parse(petInput);
                                */

                                if (petIndex > 0)
                                {
                                    // decrementing 1 to match the user input with array index
                                    petIndex--;

                                    // User confirmation
                                    Console.WriteLine();
                                    Console.WriteLine("#. {0,-10} {1}", "NAME", "TYPE");
                                    Console.WriteLine("{0}. {1,-10} {2}", petIndex + 1, pets[petIndex].Name, pets[petIndex].TypeOfPet);
                                    Console.Write("Are you sure you want to DELETE this pet (Y/N)? ");
                                    var input = Console.ReadLine();

                                    // Delete pet
                                    if (input == "Y" || input == "y")
                                    {
                                        // Squish the array from index to the end
                                        // Note: can't go up to the last array element because [i+1] will be out of bounds
                                        for (var i = petIndex; i < numberOfPets - 1; i++)
                                        {
                                            pets[i].Name = pets[i + 1].Name;
                                            pets[i].TypeOfPet = pets[i + 1].TypeOfPet;
                                        }
                                        // Clean up the last item
                                        pets[numberOfPets-1].Name = "";
                                        pets[numberOfPets-1].TypeOfPet = "";

                                        // We have one less pet
                                        numberOfPets--;
                                    }
                                }
                            }
                            break;
                        }

                    case "L":
                    case "l":
                        {
                            if (PetsExist(numberOfPets))
                            {
                                ListPets(pets, numberOfPets);
                            }

                            break;
                        }

                    case "X":
                    case "x":
                        {
                            return;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid option [{0}]. Please try again.", choice);
                            break;
                        }
                }
                Console.WriteLine("");
            }
        }

    }
}

