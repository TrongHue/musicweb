using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using musicweb.Models;

namespace musicweb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Play()
        {

            return View();
        }
      [HttpGet]
        public JsonResult GetSource(string  source)
        {
            TempData["Source"] = source;
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult search()
        {
            return View();
        }
        public ActionResult Artist()
        {
            return View();
        }
        public ActionResult songByArtist()
        {
            return View();
        }
        public ActionResult Album()
        {
            return View();
        }
        public ActionResult SongInAlbum()
        {
            return View();
        }
        public ActionResult Top10()
        {
            return View();
        }
[HttpGet]
        public JsonResult GetSourceList(string type)
        {
            TempData["type"] = type;
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult playlisttop10() {
            
            return View();
        }
        public ActionResult Type()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(users u)
        {
                if (ModelState.IsValid)
                {
                    using (DTcontext db = new DTcontext())
                    {
                        var v = db.userList.Where(us => us.userName.Equals(u.userName) && us.userPass.Equals(u.userPass)).FirstOrDefault();
                        if (v != null)
                        {
                            Session["logedUserID"] = v.userID.ToString();
                            Session["logedUserFullName"] = v.userName.ToString();
                            return RedirectToAction("Afterlogin");
                        }

                    }
                }
                return View("Index");
            
        }
   
        public ActionResult Afterlogin()
        {
            if (Session["logedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Logout()
        {

            Session["logedUserID"] = null;
            return RedirectToAction("Index");
        }
        public ActionResult favor() {
            if (Session["logedUserID"] == null)
            {
                return RedirectToAction("logout");
            }
            return View();
        }
        public ActionResult playvideo() {
            return View();
        }
       
    }


}