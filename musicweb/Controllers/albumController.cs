using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using musicweb.Models;
namespace musicweb.Controllers
{
    public class albumController : ApiController
    {
        DTcontext db = new DTcontext();
        public IHttpActionResult Get()
        {
            var listalbum = db.albumList.Except(db.albumList.Where(a=>a.albumName.Contains("Single")));

            return Ok(listalbum);
        }
        public IHttpActionResult Get(int cout)
        {

            var listalbum = db.albumList.OrderByDescending(a=>a.albumTimrelease);
            var count = cout == 0 ? listalbum.Count() : cout;
            return Ok(listalbum.Take(count));
        }
    }
}
