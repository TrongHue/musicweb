using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace musicweb.Models
{
    public class song
    {
        

        [Key]
        public int songCode { get; set; }

        public string songName { get; set; }

        public string songSource { get; set; }

        public string songPicture { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime timRelease { get; set; }

        public string songType { get; set; }

        public string songSinger { get; set; }
        public int albumID { get; set; }

        public int songListened { get; set; }
        [ForeignKey("albumID")]
        public virtual album songinalbum { get; set; }
    }
}