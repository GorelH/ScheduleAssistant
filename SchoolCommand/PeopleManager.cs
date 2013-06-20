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
        public static bool DeletePerson(int personId)
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
                String selectClause = "SELECT * FROM People";
                String whereClause = string.Empty;
                String sql = string.Empty;

                if (!string.IsNullOrEmpty(name))
                {
                    whereClause = "People.Name LIKE '%" + name + "%'";
                }
                if (!string.IsNullOrEmpty(address))
                {
                    if (!string.IsNullOrEmpty(whereClause))
                        whereClause += " AND ";
                    whereClause += "People.Address LIKE '%" + address + "%'";
                }
                if (!string.IsNullOrEmpty(age))
                {
                    if (!string.IsNullOrEmpty(whereClause))
                        whereClause += " AND ";
                    whereClause += "People.Age LIKE '%" + age + "%'";
                }
                if (!string.IsNullOrEmpty(phone))
                {
                    if (!string.IsNullOrEmpty(phone))
                        whereClause += " AND ";
                    whereClause += "People.Phone LIKE '%" + phone + "%'";
                }

                if (!string.IsNullOrEmpty(whereClause))
                {
                    sql = selectClause + " WHERE " + whereClause;
                }
                else
                {
                    sql = selectClause;
                }

                var select1 = db.People.SqlQuery(sql);

                List<Person> results = select1.ToList<Person>();

                return results;
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
