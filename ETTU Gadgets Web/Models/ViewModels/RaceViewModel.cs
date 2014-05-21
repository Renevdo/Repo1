using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETTU_Gadgets_Web.Models.ViewModels
{
    public class RaceViewModel
    {
        [Required]
        public int Boat1 { get; set; }
        [Required]
        public int Boat2 { get; set; }

        public Race Race { get; set; }
    }
}