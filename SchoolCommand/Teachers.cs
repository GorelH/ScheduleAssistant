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
    
    public partial class Teachers
    {
        public int TeacherId { get; set; }
        public string PersonId { get; set; }
    
        public virtual HasSpecialty HasSpecialty { get; set; }
        public virtual Person Person { get; set; }
    }
}
