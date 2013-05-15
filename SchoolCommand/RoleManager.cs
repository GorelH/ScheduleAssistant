using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCommand
{
    class RoleManager
    {
        public static int GetRoleID(String roleTitle)
        {
            using (var db = new Entities())
            {
                var role = from r in db.Roles
                           where ((roleTitle != null) ? r.Name == roleTitle : false)
                           select r;
                return (role.First() != null) ? role.First().Id : -1;
            }
        }

        public static Roles GetRole(String roleTitle)
        {
            using (var db = new Entities())
            {
                var role = from r in db.Roles
                           where ((roleTitle != null) ? r.Name == roleTitle : false)
                           select r;
                return (role.First() != null) ? role.First() : null;
            }
        }

        public static Roles GetRole(int roleId)
        {
            using (var db = new Entities())
            {
                var role = from r in db.Roles
                           where r.Id == roleId
                           select r;
                return (role.First() != null) ? role.First() : null;
            }
        }

        public static int AddRole(String title)
        {
            using (var db = new Entities())
            {
                int count = db.Roles.Count() + 1;
                db.Roles.Add(new Roles
                {
                    Name = title,
                    Id = count
                });
                return db.SaveChanges();
            }
        }

        public static int RemoveRole(int roleId)
        {
            using (var db = new Entities())
            {
                db.Roles.Remove(db.Roles.Find(roleId));
                return db.SaveChanges();
            }
        }
    }
}
