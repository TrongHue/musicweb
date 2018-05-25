using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace musicweb.Models
{
    public class video
    {
        [Key]
        public int videoID { get; set; }
        public string videoName { get; set; }
        public string videoPic { get; set; }
        public string videoSource { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime videoTimerelease { get; set; }
        public int videoListened { get; set; }

    }
}