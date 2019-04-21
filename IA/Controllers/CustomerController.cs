using IA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA.Controllers
{
    public class CustomerController : Controller
    {
        private AppDbContext _context = new AppDbContext();
        public ActionResult CustomerProfile()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            var Customer = _context.Users.Find(userId);
            
            return View(Customer);
        }

        public ActionResult ListCurrentProjects()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            //var Projects = _context.Users.FirstOrDefault(u => u.UserId == userId).Projects.ToList();
            return View();
        }

        public ActionResult ListDeliveredProjects()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(Project _project)
        {
            return View();
        }

        public ActionResult DeleteProject()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditProject(Project _project)
        {
            return View();
        }

        [HttpGet]
        public ActionResult AssignProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AssignProject(Project _project)
        {
            return View();
        }
    }
}
