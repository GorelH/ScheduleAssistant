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
    
    public partial class GroupHasTimeslot
    {
        public int Id { get; set; }
        public int TimeslotId { get; set; }
        public string GroupId { get; set; }
    
        public virtual Groups Group { get; set; }
        public virtual Timeslots Timeslot { get; set; }
    }
}
