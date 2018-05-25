using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using musicweb.Models;
namespace musicweb.Controllers
{
    public class UserdoController : ApiController
    {
        DTcontext db = new DTcontext();
        public IHttpActionResult getall()
        {
            return Ok(db.userSongList);
        }
        public IHttpActionResult getSong( int userID)
        {
            var userSong = db.userSongList.Where(u => u.userID == userID);
            return Ok(userSong);
        }
        public void addUserSong(usersong u)
        {

            db.userSongList.Add(u);
            db.SaveChanges();
        }
     
       
    }
}
