//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolCommand
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person
    {
        public Person()
        {
            this.HasSpecialties = new HashSet<HasSpecialty>();
            this.HasRoles = new HashSet<HasRole>();
            this.HasGroups = new HashSet<HasGroup>();
        }
    
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
    
        public virtual ICollection<HasSpecialty> HasSpecialties { get; set; }
        public virtual ICollection<HasRole> HasRoles { get; set; }
        public virtual ICollection<HasGroup> HasGroups { get; set; }
    }
}
