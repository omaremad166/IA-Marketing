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
    public class MarketingDirectorController : Controller
    {
        private AppDbContext _context = new AppDbContext();

        public ActionResult MarketingDirectorProfile()
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
            

            if (request.Sender.Role.RoleId == 5)
            {
                int UserId = Convert.ToInt32(request.SenderId);
                int ProjectId = request.ProjectId;
                UserProject userProject = _context.UserProjects.Where(up => up.ProjectId == ProjectId && up.UserId == UserId).FirstOrDefault();
                _context.UserProjects.Remove(userProject);
                _context.Requests.Remove(request);
                _context.SaveChanges();
            }
            else
            {
                UserProject userProject = new UserProject();
                userProject.ProjectId = request.ProjectId;
                userProject.UserId = Convert.ToInt32(Session["UserId"]);
                _context.UserProjects.Add(userProject);

                Project project = _context.Projects.Find(request.ProjectId);
                project.ProjectStateId = 2;
                _context.Entry(project).State = EntityState.Modified;

                List<Request> requests = _context.Requests.Where(r => r.ProjectId == request.ProjectId).ToList();

                foreach (var r in requests)
                {
                    _context.Requests.Remove(r);
                }
                _context.SaveChanges();
            }
           
            return RedirectToAction("MarketingDirectorProfile");
        }

        public ActionResult RejectRequest(int RequestId)
        {
            Request request = _context.Requests.Find(RequestId);
            _context.Requests.Remove(request);
            _context.SaveChanges();

            return RedirectToAction("MarketingDirectorProfile");
        }

        [HttpGet]
        public ActionResult AddMember(int ProjectId)
        {
            Project project = _context.Projects.Find(ProjectId);
            List<User> users = _context.Users.Where(u => u.RoleId == 4 || u.RoleId == 5).ToList();

            ProjectUsersViewModel ProjectUsersVM = new ProjectUsersViewModel();
            ProjectUsersVM.Project = project;
            ProjectUsersVM.Users = users;

            return View(ProjectUsersVM);
        }

        [HttpPost]
        public ActionResult AddMember()
        {
            Request request = new Request();

            request.ProjectId = Convert.ToInt32(Request.Form["ProjectId"]);
            request.SenderId = Convert.ToInt32(Session["UserId"]);
            request.ReceiverId = Convert.ToInt32(Request.Form["TeamMemberId"]);

            _context.Requests.Add(request);
            _context.SaveChanges();

            return RedirectToAction("MarketingDirectorProfile");
        }

        [HttpGet]
        public ActionResult ManageProject(int ProjectId)
        {
            Project project = _context.Projects.Find(ProjectId);
            return View(project);
        }

        [HttpPost]
        public ActionResult ManageProject(Project _project)
        {
            _context.Entry(_project).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("MarketingDirectorProfile");
        }

        [HttpGet]
        public ActionResult RemoveMember(int ProjectId)
        {
            List<UserProject> userProjects = _context.UserProjects.Where(up => up.ProjectId == ProjectId).Include(u => u.User).Where(u => u.User.RoleId == 4 || u.User.RoleId == 5).ToList();
            ViewBag.ProjectId = ProjectId;

            return View(userProjects);
        }

        [HttpPost]
        public ActionResult RemoveMember()
        {
            UserProject userProject = _context.UserProjects.Find(Convert.ToInt32(Request.Form["TeamMemberId"]), Convert.ToInt32(Request.Form["ProjectId"]));
            _context.UserProjects.Remove(userProject);
            _context.SaveChanges();

            return RedirectToAction("MarketingDirectorProfile");
        }

        public ActionResult LeaveProject(int ProjectId)
        {
            UserProject userProject = _context.UserProjects.Find(Convert.ToInt32(Session["UserId"]), ProjectId);
            _context.UserProjects.Remove(userProject);
            _context.SaveChanges();

            return RedirectToAction("MarketingDirectorProfile");
        }

        public ActionResult FinishProject(int ProjectId)
        {
            Project project = _context.Projects.Find(ProjectId);

            project.ProjectStateId = 4;
            _context.Entry(project).State = EntityState.Modified;

            List<Request> requests = _context.Requests.Where(r => r.ProjectId == ProjectId).ToList();

            foreach (Request r in requests)
            {
                _context.Requests.Remove(r);
            }

            _context.SaveChanges();

            return RedirectToAction("MarketingDirectorProfile");
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