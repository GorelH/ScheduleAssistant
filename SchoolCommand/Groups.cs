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
    
    public partial class Groups
    {
        public Groups()
        {
            this.HasGroups = new HashSet<HasGroup>();
            this.GroupHasTimeslots = new HashSet<GroupHasTimeslot>();
        }
    
        public int GroupId { get; set; }
        public string RoomId { get; set; }
        public string Subject { get; set; }
    
        public virtual ICollection<HasGroup> HasGroups { get; set; }
        public virtual Rooms Room { get; set; }
        public virtual ICollection<GroupHasTimeslot> GroupHasTimeslots { get; set; }
    }
}
