using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCommand
{
    class PeopleManager
    {
        public string type
        {
            get
            {
                return this._type;
            }
        }

        public int mode
        {
            get
            {
                return this._mode;
            }
        }

        private string _type;
        private int _mode;

        public PeopleManager(int mode)
        {
            switch (mode)
            {
                case 1:
                    _type = "Person";
                    this._mode = mode;
                    break;
                case 2:
                    _type = "Student";
                    this._mode = mode;
                    break;
                case 3:
                    _type = "Teacher";
                    this._mode = mode;
                    break;
            }
            Start();
        }

        private void Start()
        {
            int choice;
            while(true)
            {
            Console.Clear();
            Console.WriteLine("===========PEOPLE MANAGER===========");

            /*using (var db = new Entities())
            {
                int i = 1;
                foreach(Roles r in db.Roles)
                {
                    Console.WriteLine("" + i + ") Manage " + r.Name);
                }
            }*/

            Console.WriteLine("1) Manage People\nReturn to main menu");

            choice = Convert.ToInt32(Console.ReadLine());
            if(choice == 1)
                ManageStudents();
            else if(choice == 4)
                break;

            }    
        }

        public bool AddPerson(String name, String address, String age, String phone)
        {
            var person = new Person
            {
                Name = name,
                Address = address,
                Age = age,
                Phone = phone
            };

            using (var db = new Entities())
            {
                db.People.Add(person);

                if (db.SaveChanges() > 1)
                    return true;
                else
                    return false;
            }
        }
        
        public bool EditPerson(int personId, String name, String address, String age, String phone)
        {
            using (var db = new Entities())
            {
                var person = db.People.Find(personId);

                if (person == null)
                    return false;
                else
                {
                    if (!person.Address.Equals(address))
                        person.Address = address;
                    if (!person.Age.Equals(age))
                        person.Age = age;
                    if (!person.Name.Equals(name))
                        person.Name = name;
                    if (!person.Phone.Equals(phone))
                        person.Phone = phone;

                    if (db.SaveChanges() > 1)
                        return true;
                    else
                        return false;
                }
            }
        
        }
        public bool DeletePerson(int personId)
        {
            using (var db = new Entities())
            {
                var person = db.People.Find(personId);

                db.People.Remove(person);

                if (db.SaveChanges() > 1)
                    return true;
                else
                    return false;
            }
        }

        public void SearchPeople(String name, String address, String age, String phone)
        {
            using (var db = new Entities())
            {
                var listing = from p in db.People
                              where p.Phone.Equals(phone)
                              select p;
            }
        }

        


        /// <summary>
        /// Method for handling the adding, editing, and removal of students
        /// </summary>
        private void ManageStudents()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("1: Add " + this.type + "\n2: Edit " + this.type + "\n3: Delete " + this.type
                                    + "4: Exit");
                choice = Convert.ToInt16(Console.ReadKey().KeyChar);
                #region AddPerson
                if (choice == 1) // add person
                {
                    Console.Clear();
                    Console.WriteLine("=============Add=============");
                    Console.WriteLine("Name: ");
                    String name = Console.ReadLine();
                    Console.WriteLine("Address: ");
                    String address = Console.ReadLine();
                    Console.WriteLine("Age: ");
                    String age = Console.ReadLine();
                    Console.WriteLine("Phone: ");
                    String phone = Console.ReadLine();
                    var person = new Person
                    {
                        Name = name,
                        Address = address,
                        Age = age,
                        Phone = phone
                    };

                    Console.WriteLine("Add " + name + "to database?.\r\nAddress:\t" + address + "\r\nAge:\t\t" + age + "\r\nPhone:\t" + phone);
                    Console.WriteLine("Press enter to confirm. All other key discards changes.");
                    ConsoleKey bob = Console.ReadKey().Key;
                    Console.Clear();
                    if (bob == ConsoleKey.Enter)
                    {
                        using (var db = new Entities())
                        {
                            db.People.Add(person);
                            db.SaveChanges();
                        }

                        Console.WriteLine("> " + name + " added to database.");
                    }
                }
                #endregion
                #region EditPerson
                else if (choice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("===============Edit===============");
                    Console.WriteLine("Select a group of names to edit from, or tab to enter\r\na name directly.");
                    ConsoleKey bob = Console.ReadKey().Key;
                    Console.WriteLine("1)A-E\r\n2)F-J\r\n3)K-O\r\n4)P-S\r\n5)T-Z");
                    Person ps;
                    if (bob == ConsoleKey.Tab)
                    {
                        Console.WriteLine("> ");
                        string name = Console.ReadLine();
                        using (var db = new Entities())
                        {
                            foreach (Person p in db.People)
                            {
                                if (p.Name.ToString().Equals(name))
                                {
                                    ps = p;
                                    Console.WriteLine("Success! Found " + name + ".");
                                }
                            }
                        }
                    }
                    else //handle listing and selection of people
                    {
                        #region MassiveSwitch
                        switch (bob.ToString())
                        {
                            case "1":
                                Console.WriteLine("1:A\t2:B\t3:C\t4:D\t5:E");
                                ConsoleKey level2a = Console.ReadKey().Key;
                                switch (Convert.ToInt32(level2a.ToString()))
                                {
                                    case 1:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("A")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 2:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("B")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 3:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("C")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 4:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("D")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 5:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("E")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "2":
                                Console.WriteLine("1:F\t2:G\t3:H\t4:I\t5:J");
                                ConsoleKey level2b = Console.ReadKey().Key;
                                switch (Convert.ToInt32(level2b.ToString()))
                                {
                                    case 1:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("F")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 2:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("G")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 3:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("H")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 4:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("I")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 5:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("J")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "3":
                                Console.WriteLine("1:K\t2:L\t3:M\t4:N\t5:O");
                                ConsoleKey level2c = Console.ReadKey().Key;
                                switch (Convert.ToInt32(level2c.ToString()))
                                {
                                    case 1:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("K")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 2:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("L")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 3:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("M")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 4:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("N")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 5:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("O")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "4":
                                Console.WriteLine("1:P\t2:Q\t3:R\t4:S\t5:T");
                                ConsoleKey level2d = Console.ReadKey().Key;
                                switch (Convert.ToInt32(level2d.ToString()))
                                {
                                    case 1:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("P")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 2:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("Q")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 3:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("R")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 4:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("S")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 5:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("T")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "5":
                                Console.WriteLine("1:U\t2:V\t3:W\t4:X\t5:Y\t6:Z");
                                ConsoleKey level2e = Console.ReadKey().Key;
                                switch (Convert.ToInt32(level2e.ToString()))
                                {
                                    case 1:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("U")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 2:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("V")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 3:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("W")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 4:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("X")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 5:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("Y")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    case 6:
                                        using (var db = new Entities())
                                        {
                                            int i = 0;
                                            var listing = from p in db.People
                                                          where p.Name.StartsWith("Z")
                                                          select p;
                                            foreach (Person p in listing)
                                                Console.WriteLine((i++) + p.Name);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        #endregion
                    }
                #endregion
                }
                #region RemovePerson
                else if (choice == 3)
                {
                    //delete person
                    Console.Clear();
                    Console.WriteLine("==============DELETE================");
                    Console.WriteLine("Enter the name of the person to delete:");
                    string name = Console.ReadLine();
                    using (var db = new Entities())
                    {
                        try
                        {
                            var listing = from p in db.People
                                          where p.Name.Equals(name)
                                          select p;
                            if (listing.Count() > 0)
                                db.People.Remove(listing.First());
                            db.SaveChanges();
                        }
                        catch (Exception peopleRemove)
                        {
                            Console.WriteLine("Removal Failed.");
                        }
                    }
                    Console.WriteLine("Changes Saved!");
                }
                #endregion
            }
        }
    }
}
