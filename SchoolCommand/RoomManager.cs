using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCommand
{
    class RoomManager
    {
        public static bool AddRoom(String name, String location)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(location))
                throw new InvalidOperationException("Cannot add new room with " + (String.IsNullOrEmpty(name) ? "name" : "location") + " empty.");
            var room = new Rooms
            {
                Name = name,
                Location = location
            };

            using (var db = new Entities())
            {
                db.Rooms.Add(room);

                if (db.SaveChanges() > 1)
                    return true;
                else
                    return false;
            }
        }

        public bool EditRoom(int roomId, String name, String location)
        {
            using (var db = new Entities())
            {
                var room = db.Rooms.Find(roomId);

                if (room == null)
                    return false;
                else
                {
                    if (!room.Name.Equals(name))
                        room.Name = name;
                    if (!room.Location.Equals(location))
                        room.Location = location;
                    if (db.SaveChanges() > 1)
                        return true;
                    else
                        return false;
                }
            }

        }

        public bool DeleteRoom(int roomId)
        {
            using (var db = new Entities())
            {
                var person = db.Rooms.Find(roomId);
                if (person != null)
                    db.Rooms.Remove(person);
                else
                    return false;

                if (db.SaveChanges() > 1)
                    return true;
                else
                    return false;
            }
        }

        public IEnumerable<Rooms> SearchPeople(String name, String location)
        {
            using (var db = new Entities())
            {
                
                String selectClause = "SELECT * FROM Rooms";
                String whereClause = string.Empty;
                String sql = string.Empty;

                if (!string.IsNullOrEmpty(name))
                {
                    whereClause = "Rooms.Name LIKE '%" + name + "%'";
                }
                if (!string.IsNullOrEmpty(location))
                {
                    if (!string.IsNullOrEmpty(location))
                        whereClause += " AND ";
                    whereClause += "Rooms.Phone LIKE '%" + location + "%'";
                }

                if (!string.IsNullOrEmpty(whereClause))
                {
                    sql = selectClause + " WHERE " + whereClause;
                }
                else
                {
                    sql = selectClause;
                }

                var select1 = db.Rooms.SqlQuery(sql);

                List<Rooms> results = select1.ToList<Rooms>();

                return results;
            }
        }
    }
}
