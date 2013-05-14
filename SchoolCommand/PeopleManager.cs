﻿using System;
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

        public IEnumerable<Person> SearchPeople(String name, String address, String age, String phone)
        {
            using (var db = new Entities())
            {
                //var select1 = (phone != null) ? db.People.Where(x => phone.Equals(phone)) : (age != null) ? db.People.Where(x=> x.Age.Equals(age)) : 
                //    (address != null)? db.People.Where(x => x.Address.Equals(address)) : ((name != null)? db.People.Where( p => p.Name.Equals(name)) : null);

                var select1 = from p in db.People
                              where ((name != null) ? p.Name == name : true) &&
                              ((address != null) ? p.Address == address : true) &&
                              ((age != null) ? p.Age == age : true) &&
                              ((phone != null) ? p.Phone == phone : true)
                              select p;
                return select1;


            }

        }

        /// <summary>
        /// Adds or removes a specialty from a given person. Creates the specialty if it
        /// doesn't pre-exist.
        /// </summary>
        /// <param name="personId">The ID of the person</param>
        /// <param name="specialtyTitle">The title text of the specialty</param>
        /// <param name="specialtyText">The description of the specialty</param>
        private void ModifySpecialties(int personId, String specialtyTitle, String specialtyText)
        {

        }
    }
}
