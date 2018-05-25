using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace musicweb.Models
{
    public class album
    {
        [Key]
        public int albumID { get; set; }
        public string albumName { get; set; }
        public string albumPic { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime albumTimrelease { get; set; }
        
    }
}