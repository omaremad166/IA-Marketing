using IA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA.Controllers
{
    public class UserController : Controller
    {
        AppDbContext db = new AppDbContext();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.RoleId = 2;
            db.Users.Add(user);
            db.SaveChanges();
            return View();
        }
    }
}