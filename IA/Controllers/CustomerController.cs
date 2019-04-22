using IA.Models;
using IA.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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

            UserProjectsViewModel UserProjectsVM = new UserProjectsViewModel();
            UserProjectsVM.User = _context.Users.Find(userId);

            var ProjectIds = _context.UserProjects.Where(up => up.UserId == userId).Select(up => up.ProjectId).ToList();
            var Projects = _context.Projects.Where(p => ProjectIds.Contains(p.ProjectId)).ToList();

            UserProjectsVM.Projects = Projects;

            return View(UserProjectsVM);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(Project _project)
        {
            _project.ProjectStateId = 1;
            _context.Projects.Add(_project);

            UserProject userProject = new UserProject();
            userProject.UserId = Convert.ToInt32(Session["UserId"]);
            userProject.ProjectId = _project.ProjectId;
            _context.UserProjects.Add(userProject);
            
            _context.SaveChanges();
            return RedirectToAction("CustomerProfile");
        }

        public ActionResult DeleteProject(int? ProjectId)
        {
            Project project = _context.Projects.Find(ProjectId);
            _context.Projects.Remove(project);

            var requests = _context.Requests.Where(r => r.ProjectId == ProjectId);
            foreach(Request r in requests)
            {
                _context.Requests.Remove(r);
            }

            var userprojects = _context.UserProjects.Where(up => up.ProjectId == ProjectId);
            foreach (UserProject up in userprojects)
            {
                _context.UserProjects.Remove(up);
            }

            _context.SaveChanges();

            return RedirectToAction("CustomerProfile");
        }

        [HttpGet]
        public ActionResult EditProject(int? ProjectId)
        {
            Project project = _context.Projects.Find(ProjectId);
            return View(project);
        }

        [HttpPost]
        public ActionResult EditProject(Project _project)
        {
            _context.Entry(_project).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("CustomerProfile");
        }

        [HttpGet]
        public ActionResult AssignProject(int id)
        {
            ProjectUsersViewModel ProjectUsersVM = new ProjectUsersViewModel();

            ProjectUsersVM.Project = _context.Projects.Find(id);
            ProjectUsersVM.Users = _context.Users.Where(u => u.RoleId == 3).ToList();
            ProjectUsersVM.Request = new Request();

            return View(ProjectUsersVM);
        }

        [HttpPost]
        public ActionResult AssignProject()
        {
            Request request = new Request();
            request.ProjectId =Convert.ToInt32(Request.Form["ProjectId"]) ;
            request.SenderId =Convert.ToInt32(Session["UserId"]) ;
            request.ReceiverId = Convert.ToInt32(Request.Form["DirectorId"]) ;
            
            _context.Requests.Add(request);
            _context.SaveChanges();

            return RedirectToAction("CustomerProfile");
        }
    }
}
