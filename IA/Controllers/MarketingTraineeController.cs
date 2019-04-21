using IA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA.Controllers
{
    public class MarketingTraineeController : Controller
    {
        public ActionResult MarketingTraineeProfile()
        {
            return View();
        }

        public ActionResult ViewRequests()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RespondRequests(Request _request)
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

        [HttpPost]
        public ActionResult LeaveProjectRequest(Project _project)
        {
            return View();
        }
    }
}