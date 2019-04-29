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
    public class MarketingTeamLeaderController : Controller
    {
        private AppDbContext _context = new AppDbContext();

        public ActionResult MarketingTeamLeaderProfile()
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

            return RedirectToAction("MarketingTeamLeaderProfile");
        }

        public ActionResult RejectRequest(int RequestId)
        {
            Request request = _context.Requests.Find(RequestId);
            _context.Requests.Remove(request);
            _context.SaveChanges();

            return RedirectToAction("MarketingTeamLeaderProfile");
        }

        [HttpGet]
        public ActionResult AddMember(int ProjectId)
        {
            Project project = _context.Projects.Find(ProjectId);
            List<User> users = _context.Users.Where(u => u.RoleId == 5).ToList();

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

            return RedirectToAction("MarketingTeamLeaderProfile");
        }

        [HttpGet]
        public ActionResult RemoveMember(int ProjectId)
        {
            List<UserProject> userProjects = _context.UserProjects.Where(up => up.ProjectId == ProjectId).Include(u => u.User).Where(u => u.User.RoleId == 5).ToList();
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

            return RedirectToAction("MarketingTeamLeaderProfile");
        }
    }
}