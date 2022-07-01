using System;
using System.Collections.Generic;

namespace PersonManagement
{
    internal class Program
    {
        public static List<Person> Persons { get; set; } = new List<Person>();
        static void Main(string[] args)
        {

            Console.WriteLine("Our available commands :");
            Console.WriteLine("/add-new-person");
            Console.WriteLine("/remove-person-by-fin");
            Console.WriteLine("/remove-person-by-id");
            Console.WriteLine("/show-persons");
            Console.WriteLine("/remove-all-persons");
            Console.WriteLine("/exit");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command : ");
                string command = Console.ReadLine();

                if (command == "/add-new-person")
                {
                    Console.Write("Please add person's name :");
                    string name = Console.ReadLine();

                    Console.Write("Please add person's surname :");
                    string lastName = Console.ReadLine();

                    Console.Write("Please add person's FIN code :");
                    string fin = Console.ReadLine();

                    Person person = AddNewPerson(name, lastName, fin);

                    Console.WriteLine(person.GetInfo() + " - Added to system.");

                }
                else if (command == "/remove-person-by-fin")
                {
                    Console.Write("To remove person, please enter his/her FIN code : ");
                    string fin = Console.ReadLine();
                    for (int i = 0; i < Persons.Count; i++)
                    {
                        if (Persons[i].FIN == fin)
                        {
                            Console.WriteLine(Persons[i].GetInfo());
                            Persons.RemoveAt(i);
                            Console.WriteLine("Person removed successfully");
                        }
                    }

                }
                else if (command == "/remove-person-by-id")
                {
                    Console.Write("To remove person, please enter his/her ID code : ");
                    uint id = Convert.ToUInt32(Console.ReadLine());
                    for (int i = 0; i < Persons.Count; i++)
                    {
                        if (Persons[i].Id == id)
                        {
                            Console.WriteLine(Persons[i].GetInfo());
                            Persons.RemoveAt(i);
                            Console.WriteLine("Person removed successfully");
                        }
                    }

                }
                else if (command == "/show-persons")
                {
                    Console.WriteLine("Persons in database : ");
                    foreach (Person person in Persons)
                    {
                        Console.WriteLine(person.GetInfo());
                    }
                }
                else if (command == "/remove-all-persons")
                {
                    for (int i = 0; i <= Persons.Count; i++)
                    {
                        Persons.RemoveAt(0);
                    }
                    Console.WriteLine("All persons removed successfully");
                }
                else if (command == "/exit")
                {
                    Console.WriteLine("Thanks for using our application!");
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found, please enter command from list!");
                    Console.WriteLine();
                }
            }
        }
        public static Person AddNewPerson(string name, string lastname, string fin)
        {
            Person person = new Person(name, lastname, fin);
            Persons.Add(person);
            return person;
        }
        
    }


    class Person
    {
        public static uint currentIdCount = 1;
        
        public uint Id { get; private set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FIN { get; set; }

        public Person(string name, string lastName, string fin)
        {
            Id = currentIdCount;
            Name = name;
            LastName = lastName;
            FIN = fin;

            currentIdCount++;
        }

        public string GetFullName()
        {
            return Name + " " + LastName;
        }

        public string GetInfo()
        {
            return Id + " " + Name + " " + LastName + " " + FIN;
        }
    }
}
