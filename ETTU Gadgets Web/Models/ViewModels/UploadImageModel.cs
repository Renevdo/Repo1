using ETTU_Gadgets_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETTU_Gadgets_Web.Views.Shared
{
    public class UploadImageModel
    {
        public HttpPostedFileBase UploadImage { get; set; }
    }
}