using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace musicweb.Models
{
    public class usersong
    {[Key,Column(Order =1)]
        public int songID { get; set; }
    [Key, Column(Order = 2)]
        public int userID { get; set; }
        [ForeignKey("songID")]
        public virtual song songs { get; set; }
        [ForeignKey("userID")]
        public virtual users users { get; set; }
    }
}