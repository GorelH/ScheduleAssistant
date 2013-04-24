using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCommand
{
    class PeopleManager
    {
        public static bool AddPerson(String name, String address, String age, String phone)
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
    }
}
