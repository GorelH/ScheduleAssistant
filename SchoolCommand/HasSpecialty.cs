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
    
    public partial class HasSpecialty
    {
        public HasSpecialty()
        {
            this.Teachers = new HashSet<Teachers>();
            this.Students = new HashSet<Students>();
        }
    
        public int Id { get; set; }
    
        public virtual ICollection<Teachers> Teachers { get; set; }
        public virtual ICollection<Students> Students { get; set; }
        public virtual Specialities Speciality { get; set; }
    }
}
