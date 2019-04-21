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
        public ActionResult CustomerProfile()
        {
            return View();
        }

        public ActionResult ListCurrentProjects()
        {
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
