//#define useDB
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCommand
{
    class Program
    {
        private bool useDB = false;


        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1) Manage People\n2) Manage Rooms\n3) Create Schedules\n4) Print Schedules");
                int choice = Convert.ToInt32(Console.ReadLine());

               
                if (choice == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("1) Add Preson\n2) Edit Person\n3) Delete Person\n4) Search People");
                        choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.Write("Name: ");
                            String name = Console.ReadLine();
                            Console.Write("Address: ");
                            String address = Console.ReadLine();
                            Console.Write("Age: ");
                            String age = Console.ReadLine();
                            Console.Write("Phone: ");
                            String phone = Console.ReadLine();

                            if(PeopleManager.AddPerson(name, address, age, phone))
                                Console.WriteLine("Success!");
                            else
                                Console.WriteLine("Failure!");
                        }
                        else if (choice == 2)
                        { }
                        else if (choice == 3)
                        {
                            Console.WriteLine("Person Id");
                            choice = Convert.ToInt32(Console.ReadLine());

                            PeopleManager.DeletePerson(choice);
                        }
                        else if (choice == 4)
                        {
                            Console.WriteLine("Leave any of the following fields blank to ignore it");

                            Console.Write("Name: ");
                            String name = Console.ReadLine();
                            Console.Write("Address: ");
                            String address = Console.ReadLine();
                            Console.Write("Age: ");
                            String age = Console.ReadLine();
                            Console.Write("Phone: ");
                            String phone = Console.ReadLine();

                            foreach(Person p in PeopleManager.SearchPeople(name, address, age, phone))
                            {
                                Console.WriteLine("ID: " + p.PersonId);
                                Console.WriteLine("Name: " + p.Name);
                                Console.WriteLine("Age: " + p.Age);
                                Console.WriteLine("Phone: " + p.Phone);
                                Console.WriteLine("Address: " + p.Address);
                                Console.WriteLine("============================================");
                            }

                        }
                        else if (choice == 5)
                        { break; }
                    }
                }
                else if (choice == 2)
                { }
                else if (choice == 3)
                { }
                else if (choice == 4)
                { }
                else if (choice == 5)
                { break; }
            }            
        }
    }
}
