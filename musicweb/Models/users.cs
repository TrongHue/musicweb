using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace musicweb.Models
{
    public class users
    {
        [Key]
        public int userID { get; set; }
        public string userName { get; set; }
        public string userPass { get; set; }
 
    }
}