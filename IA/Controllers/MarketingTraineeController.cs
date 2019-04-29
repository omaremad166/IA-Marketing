using IA.Models;
using IA.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA.Controllers
{
    public class MarketingTraineeController : Controller
    {
        private AppDbContext _context = new AppDbContext();

        public ActionResult MarketingTraineeProfile()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            UserProjectsRequestsViewModel UserProjectsVM = new UserProjectsRequestsViewModel();
            UserProjectsVM.User = _context.Users.Find(userId);

            var ProjectIds = _context.UserProjects.Where(up => up.UserId == userId).Select(up => up.ProjectId).ToList();
            var Projects = _context.Projects.Where(p => ProjectIds.Contains(p.ProjectId)).ToList();

            UserProjectsVM.Projects = Projects;

            var requests = _context.Requests.Where(r => r.ReceiverId == userId).Include(r => r.Project).Include(r => r.Sender).ToList();
            UserProjectsVM.Requests = requests;

            return View(UserProjectsVM);
        }

        public ActionResult AcceptRequest(int RequestId)
        {
            Request request = _context.Requests.Find(RequestId);

            UserProject userProject = new UserProject();
            userProject.ProjectId = request.ProjectId;
            userProject.UserId = Convert.ToInt32(Session["UserId"]);

            _context.UserProjects.Add(userProject);
            _context.Requests.Remove(request);
            _context.SaveChanges();

            return RedirectToAction("MarketingTraineeProfile");
        }

        public ActionResult RejectRequest(int RequestId)
        {
            Request request = _context.Requests.Find(RequestId);
            _context.Requests.Remove(request);
            _context.SaveChanges();

            return RedirectToAction("MarketingTraineeProfile");
        }

        public ActionResult LeaveProject(int ProjectId)
        {
            Request request = new Request();
            request.ProjectId = ProjectId;
            request.SenderId = Convert.ToInt32(Session["UserId"]);

            var userProject = _context.UserProjects.Where(up => up.ProjectId == ProjectId && up.User.RoleId == 3).Single();

            request.ReceiverId = userProject.UserId;

            _context.Requests.Add(request);
            _context.SaveChanges();

            return RedirectToAction("MarketingTraineeProfile");
        }

        public JsonResult GetData()
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            var Projects = _context.UserProjects.Where(up => up.UserId == UserId).Include(up => up.User).Include(up => up.Project).ToList();

            int InProgressNo = Projects.Where(p => p.Project.ProjectStateId == 2).Count();
            int FinishedNo = Projects.Where(p => p.Project.ProjectStateId == 4).Count();

            Ratio ratio = new Ratio();
            ratio.Finished = FinishedNo;
            ratio.InProgress = InProgressNo;

            return Json(ratio, JsonRequestBehavior.AllowGet);
        }

        public class Ratio
        {
            public int Finished { get; set; }
            public int InProgress { get; set; }
        }
    }
}