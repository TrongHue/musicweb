using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using musicweb.Models;

namespace musicweb.Controllers
{
    public class videoController : ApiController
    {
        DTcontext db = new DTcontext();
        public IHttpActionResult Get() {
            var Listvideo = db.videoList;
            return Ok(Listvideo);
        }
        public IHttpActionResult getnewvideo(int cout) {
            var Listvideo = db.videoList.OrderByDescending(v => v.videoTimerelease);
            var count = cout == 0 ? Listvideo.Count() : cout;
            return Ok(Listvideo.Take(count));
        }
        public IHttpActionResult getTopVideo(int couttop) {
            DateTime d = DateTime.Now;
            var listvideo = db.videoList.Where(v => v.videoTimerelease.Year.Equals(d.Year)).OrderByDescending(v=>v.videoListened);
            return Ok(listvideo.Take(couttop));
        }
        public IHttpActionResult UpdateVideoCout(video v)
        {
            var videoupdate = db.videoList.Find(v.videoID);
            videoupdate.videoID = v.videoID;
            videoupdate.videoName = v.videoName;
            videoupdate.videoPic = v.videoPic;
            videoupdate.videoSource = v.videoSource;
            videoupdate.videoListened = v.videoListened;
            videoupdate.videoTimerelease = v.videoTimerelease;
            db.Entry(videoupdate).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(videoupdate);
        }
        public IHttpActionResult GetvideobySource(string source) {
            var video = db.videoList.Where(v => v.videoSource.Contains(source));
            return Ok(video);
        }

    }
}
