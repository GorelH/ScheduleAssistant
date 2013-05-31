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

                if (db.SaveChanges() > 0)
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

                    if (db.SaveChanges() > 0)
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

                if (db.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }

        public static IEnumerable<Object> SearchPeople(String name, String address, String age, String phone)
        {
            using (var db = new Entities())
            {
                //var select1 = (phone != null) ? db.People.Where(x => phone.Equals(phone)) : (age != null) ? db.People.Where(x=> x.Age.Equals(age)) : 
                //    (address != null)? db.People.Where(x => x.Address.Equals(address)) : ((name != null)? db.People.Where( p => p.Name.Equals(name)) : null);

                /*var select1 = from p in db.People
                              where (name != null && !(name.Trim().Equals("")) ? p.Name == name : true) &&
                              (address != null && !(address.Trim().Equals("")) ? p.Address == address : true) &&
                              (age != null && !(age.Trim().Equals("")) ? p.Age == age : true) &&
                              (name != null && !(name.Trim().Equals("")) ? p.Phone == phone : true)
                              select p;*/
                String selectClause = "SELECT * FROM People p";
                String whereClause = string.Empty;
                String sql = string.Empty;


                int index = 0;
                List<String> parm = new List<String>();

                if (!string.IsNullOrEmpty(name))
                {
                    whereClause = "p.Name = {" + index++ + "}";
                    parm.Add(name);
                }
                if (!string.IsNullOrEmpty(address))
                {
                    if (!string.IsNullOrEmpty(whereClause))
                        whereClause += " AND ";
                    whereClause += "p.Address = {" + index++ + "}";
                    parm.Add(address);
                }
                if (!string.IsNullOrEmpty(age))
                {
                    if (!string.IsNullOrEmpty(whereClause))
                        whereClause += " AND ";
                    whereClause += "p.Age = {" + index++ + "}";
                    parm.Add(age);
                }
                if (!string.IsNullOrEmpty(phone))
                {
                    if (!string.IsNullOrEmpty(phone))
                        whereClause += " AND ";
                    whereClause += "p.Phone = {" + index++ + "}";
                    parm.Add(phone);
                }

                if (!string.IsNullOrEmpty(whereClause))
                {
                    sql = selectClause + " WHERE " + whereClause;
                }

                var select1 = db.People.SqlQuery(sql, parm.ToArray());

                return select1.ToList();
            }

        }

        /// <summary>
        /// Adds or removes a specialty from a given person. Creates the specialty if it
        /// doesn't pre-exist.
        /// </summary>
        /// <param name="personId">The ID of the person</param>
        /// <param name="specialtyTitle">The title text of the specialty</param>
        /// <param name="specialtyText">The description of the specialty</param>
        private void AddSpecialty(int personId, int specialty)
        {
            using (var db = new Entities())
            {
                //get person
                var p = db.People.Find(personId);
                if (p == null)
                    throw new InvalidOperationException("Person with person ID does not exist");

                var s = db.Specialities.Find(specialty);
                if (s == null)
                    throw new InvalidOperationException("Specialty does not exist");

                var specialties = from sp in db.HasSpecialties
                                  where sp.Person == p && sp.Speciality == s
                                  select sp;

                if (specialties.Count() > 0)
                    throw new InvalidOperationException("Added Specialty already exists for person");
                else
                {
                    int count = db.HasSpecialties.Count() + 1;
                    p.HasSpecialties.Add(new HasSpecialty
                    {
                        Person = p,
                        Speciality = s,
                        Id = count
                    });
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Adds or removes a specialty from a given person. Creates the specialty if it
        /// doesn't pre-exist.
        /// </summary>
        /// <param name="personId">The ID of the person</param>
        /// <param name="specialtyTitle">The title text of the specialty</param>
        /// <param name="specialtyText">The description of the specialty</param>
        private void RemoveSpecialty(int personId, int specialty)
        {
            using (var db = new Entities())
            {
                //get person
                var p = db.People.Find(personId);
                if (p == null)
                    throw new InvalidOperationException("Person with person ID does not exist");

                var s = db.Specialities.Find(specialty);
                if (s == null)
                    throw new InvalidOperationException("Specialty does not exist");

                var specialties = from sp in db.HasSpecialties
                                  where sp.Person == p && sp.Speciality == s
                                  select sp;

                if (specialties.Count() < 1)
                    throw new InvalidOperationException("Added Specialty does not exist for person");
                else
                {
                    p.HasSpecialties.Remove(specialties.First());
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Adds a role to a person.
        /// </summary>
        /// <param name="personId">The primary key of a person</param>
        /// <param name="roleId">The primary key of the role</param>
        private void AddRole(int personId, int roleId)
        {
            using (var db = new Entities())
            {
                var p = db.People.Find(personId);
                if (p == null)
                    throw new InvalidProgramException("No person found");
                var r = db.Roles.Find(roleId);
                if (r == null)
                    throw new InvalidProgramException("No role found.");
                var hasRole = from hr in db.HasRoles
                                   where hr.Person == p && hr.Role == r
                                   select hr;
                if (hasRole.Count() > 0)
                    throw new InvalidProgramException("Person has role already");
                else
                    p.HasRoles.Add(new HasRole
                    {
                        Person = p,
                        Role = r,
                        Id = db.HasRoles.Count() + 1
                    });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Removes a role from a person.
        /// </summary>
        /// <param name="personId">The primary key of a person</param>
        /// <param name="roleId">The primary key of the role</param>
        private void RemoveRole(int personId, int roleId)
        {
            using (var db = new Entities())
            {
                var p = db.People.Find(personId);
                if (p == null)
                    throw new InvalidProgramException("No person found");
                var r = db.Roles.Find(roleId);
                if (r == null)
                    throw new InvalidProgramException("No role found.");
                var hasRole = from hr in db.HasRoles
                              where hr.Person == p && hr.Role == r
                              select hr;
                if (hasRole.Count() < 1)
                    throw new InvalidProgramException("Person doesn't have role yet");
                else
                    p.HasRoles.Remove(hasRole.First());
                db.SaveChanges();
            }
        }
    }
}
