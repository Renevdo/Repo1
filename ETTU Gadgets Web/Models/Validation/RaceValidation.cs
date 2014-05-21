using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;
using ETTU_Gadgets_Web.Models.Validation;

namespace ETTU_Gadgets_Web.Models
{
    [MetadataType(typeof(RaceMetaData))]
    public partial class Race
    {
        public class RaceMetaData
        {
            [MaxItems(2, ErrorMessage = "Max 2 items.")]
            public virtual ICollection<Boat> Boats { get; set; }
        }
    }
}