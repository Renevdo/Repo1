//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ETTU_Gadgets_Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person
    {
        public Person()
        {
            this.RaceImages = new HashSet<RaceImage>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual Boat Boat { get; set; }
        public virtual ICollection<RaceImage> RaceImages { get; set; }
    }
}
