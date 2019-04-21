using IA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminProfile()
        {
            return View();
        }

        public ActionResult ListUsers()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User _user)
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteUser(User _user)
        {
            return View();
        }

        public ActionResult ListProjects()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteProject(User _user)
        {
            return View();
        }


    }
}
