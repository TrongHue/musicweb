using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using musicweb.Models;

namespace musicweb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(users us)
        {
            if (ModelState.IsValid)
            {
                using (DTcontext db = new DTcontext())
                {
                    db.userList.Add(us);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = us.userName + " Register success";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(users us)
        {
            using (DTcontext db = new DTcontext())
            {
                var usr = db.userList.Single(u => u.userName == us.userName && us.userPass == us.userPass);
                if (usr != null)
                {
                    Session["UserId"] = usr.userID.ToString();
                    Session["UserName"] = usr.userName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "User name or password wrong");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout() {

            Session["logedUserID"] = null;
            return RedirectToAction("Index");
        }
    }
}