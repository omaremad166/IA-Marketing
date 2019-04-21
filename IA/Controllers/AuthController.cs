using IA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA.Controllers
{
    public class AuthController : Controller
    {
        AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.RoleId = 2;
            db.Users.Add(user);
            db.SaveChanges();
            return View("Index");
        }

        [HttpPost]
        public ActionResult Login(User _user)
        {
            var user = db.Users.Where(u => u.Email.Equals(_user.Email) && u.Password.Equals(_user.Password)).FirstOrDefault();
            if (user != null)
            {
                Session["UserId"] = user.UserId.ToString();
                Session["UserName"] = user.GetUserName();
                Session["UserRole"] = user.RoleId.ToString();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index");
        }
    }
}