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
    
    public partial class Race
    {
        public Race()
        {
            this.RaceResult = new HashSet<RaceResult>();
        }
    
        public int Id { get; set; }
        public string Pool { get; set; }
        public int RaceSchemaId { get; set; }
    
        public virtual ICollection<RaceResult> RaceResult { get; set; }
        public virtual RaceSchema RaceSchema { get; set; }
    }
}