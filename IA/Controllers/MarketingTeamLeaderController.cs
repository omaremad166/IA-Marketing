using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA.Controllers
{
    public class MarketingTeamLeaderController : Controller
    {
        public ActionResult MarketingTeamLeaderProfile()
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

        public ActionResult ListTrainees()
        {
            return View();
        }

        public ActionResult SendRequest()
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