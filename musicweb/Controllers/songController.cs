using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using musicweb.Models;
namespace musicweb.Controllers
{
   
    public class songController : ApiController
    {
        DTcontext db = new DTcontext();
  
        public IHttpActionResult Get()
        {
            var listsong = db.songList;
            return Ok(listsong);
        }
        public IHttpActionResult GetSongByID(int id)
        {
            var listsong = db.songList.Where(s => s.songCode == id);
            return Ok(listsong);
        }
        public IHttpActionResult Get(int cout)
        {

            var listsong = db.songList.OrderByDescending(s => s.timRelease);
            var count = cout == 0 ? listsong.Count() : cout;
            return Ok(listsong.Take(count));
        }
        public IQueryable Getsong(string searchtext)
        {
            return db.songList.Where(s => s.songName.Contains(searchtext));

        }
        public IQueryable Getsongbysource(string source)
        {
            return db.songList.Where(s => s.songSource.Contains(source));
        }
        public IHttpActionResult getsongbyartist(string artist)
        {
            var listsong = db.songList.Where(s => s.songSinger.Contains(artist));
            return Ok(listsong);
        }
        public IHttpActionResult getsongbyalbum(int albumid)

        {
            var listsong = db.songList.Where(s=>s.albumID==albumid);
            return Ok(listsong);
        }
        public IHttpActionResult UpdateSongCout( song s)
        {
            var songupdate = db.songList.Find(s.songCode);
            songupdate.songName = s.songName;
            songupdate.songPicture = s.songPicture;
            songupdate.albumID = s.albumID;
            songupdate.songCode = s.songCode;
            songupdate.songSinger = s.songSinger;
            songupdate.songSource = s.songSource;
            songupdate.songType = s.songType;
            songupdate.songListened = s.songListened ;
            songupdate.timRelease = s.timRelease;
            db.Entry(songupdate).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(songupdate);
        }


        [HttpGet]
        public IQueryable SelectTop10byType(string type)
        {
            var ListTop10 = db.songList.Where(s => s.songType.Contains(type)).OrderByDescending(s=>s.songListened);
            
            return ListTop10.Take(10);
        }
        [HttpGet]
        public IQueryable SelectSongbyType(string typeSong)
        {
            var listSong = db.songList.Where(s => s.songType.Contains(typeSong));
            return (listSong);
        }

    }
}
