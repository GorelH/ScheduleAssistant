using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCommand
{
    class Program
    {
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
                        Console.Clear();
                        Console.WriteLine("===========PEOPLE MANAGER===========");
                        using (var db = new Entities())
                        {
                            int i = 1;
                            foreach(Roles r in db.Roles)
                            {
                                Console.WriteLine("" + i + ") Manage " + r.Name);
                            }
                        }
                        Console.WriteLine("1) Manage Students\n2) Manage Teachers\n3) Manage Case Managers\n4) Return to main menu");

                        choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 4)
                            break;
                        PeopleManager m = new PeopleManager(choice);

                        Console.WriteLine("1: Add " + m.type + "\n2: Edit " + m.type + "\n3: Delete " + m.type
                            + "4: Exit");

                        choice = Convert.ToInt16(Console.ReadKey().KeyChar);

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
                            var person = new Person();
                            //if (m.type.Equals("Case Manager"))
                            //{
                            //    person = new CaseManagers
                            //    {
                            //        Name = name,
                            //        Phone = phone,
                            //        Age = age,
                            //        Address = address
                            //    };
                            //}
                            //else
                            //{
                            //    //prompt for specialty, obtain specialty

                            //    if (m.type.Equals("Student"))
                            //    {

                            //        person = new Students
                            //        {
                            //            Name = name,
                            //            Phone = phone,
                            //            Age = age,
                            //            Address = address
                            //        };
                            //    }
                            //    else if (m.type.Equals("Teacher"))
                            //    {
                            //        person = new Teachers
                            //        {
                            //            Name = name,
                            //            Phone = phone,
                            //            Age = age,
                            //            Address = address
                            //        };
                            //    }
                            //}
                            m.AddPerson(person);

                        }
                    }
                }
                else if (choice == 2)
                { }
                else if (choice == 3)
                { }
                else if (choice == 4)
                { }
            }
            
        }
    }
}
