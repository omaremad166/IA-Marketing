using IA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA.Controllers
{
    public class AuthController : Controller
    {
        AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            //this.ViewBag.Projects = db.Projects.Where(p => p.ProjectStateId == 1).ToList();
            this.ViewBag.Projects = db.UserProjects.Include(up => up.Project).Where(up => up.Project.ProjectStateId == 1).Include(up => up.User).Where(up => up.User.RoleId == 2).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            var UserWithTheSameEmail = db.Users.Where(u => u.Email == user.Email).FirstOrDefault();
            if(ModelState.IsValid)
            {
                if (UserWithTheSameEmail == null)
                {
                    user.RoleId = 2;
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(User _user)
        {
            var user = db.Users.Where(u => u.Email.Equals(_user.Email) && u.Password.Equals(_user.Password)).FirstOrDefault();
            if (user != null)
            {
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.GetUserName();
                Session["UserRole"] = user.RoleId;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index");
        }

        public ActionResult CreateProject()
        {
            Project project = new Project();

            project.ProjectName = Request.Form["ProjectName"];
            project.Description = Request.Form["Description"];
            project.ProjectStateId = 1;

            db.Projects.Add(project);

            UserProject userProject = new UserProject();

            userProject.ProjectId = project.ProjectId;
            userProject.UserId = Convert.ToInt32(Session["UserId"]);

            db.UserProjects.Add(userProject);

            db.SaveChanges();

            return RedirectToAction("../Customer/CustomerProfile");
        }
    }
}