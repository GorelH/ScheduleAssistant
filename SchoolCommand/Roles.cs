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
    
    public partial class Roles
    {
        public Roles()
        {
            this.HasRoles = new HashSet<HasRole>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<HasRole> HasRoles { get; set; }
    }
}