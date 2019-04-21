using IA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA.Controllers
{
    public class MarketingDirectorController : Controller
    {
        public ActionResult MarketingDirectorProfile()
        {
            return View();
        }

        public ActionResult ListRequests()
        {
            return View();
        }

        public ActionResult AcceptRequest()
        {
            return View();
        }

        public ActionResult RejectRequest()
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

        public ActionResult ListTraineesAndLeaders()
        {
            return View();
        }

        public ActionResult SendRequest()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ManageProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManageProject(Project _project)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RemoveMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LeaveProject()
        {
            return View();
        }
    }
}