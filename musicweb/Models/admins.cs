using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace musicweb.Models
{
    public class admins
    {[Key]
        public int adminID { get; set; }
        public string adminName { get; set; }
        public string adminPass { get; set; }
    }
}