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
        }

        public void AddPerson(Person p)
        {

            using (var db = new Entities())
            {
                //if (p is Students)
                //{
                //    Person output = db.People.Add(p);
                    
                //}

                //else if (p is Teachers)
                //{ }
                //else if (p is CaseManagers)
                //{ }
                db.SaveChanges();
            }

        }
    }
}
