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
            var room = new Rooms
            {

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

                db.Rooms.Remove(person);

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
                //var select1 = (phone != null) ? db.People.Where(x => phone.Equals(phone)) : (age != null) ? db.People.Where(x=> x.Age.Equals(age)) : 
                //    (address != null)? db.People.Where(x => x.Address.Equals(address)) : ((name != null)? db.People.Where( p => p.Name.Equals(name)) : null);

                var select1 = from r in db.Rooms
                              where ((name != null) ? r.Name == name : true) &&
                              ((location != null) ? r.Location == location : true)
                              select r;
                return select1;


            }
        }
    }
}
