using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IA.Models;
using System.Net.Http;
namespace IA.Controllers
{
    public class AdminController : Controller
    {
        private IA.AppDbContext db = new IA.AppDbContext();
        // GET: Admin

        public ActionResult AdminProfile()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            User user = db.Users.Find(userId);

            return View(user);
        }

        public ActionResult ListUsers()
        {
            return View(db.Users.ToList());
        }

        public ActionResult AddUser()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser([Bind(Include =
"FirstName,LastName,Email,Password,PhoneNo,Description,RoleId")] User user)
        {
            var UserWithTheSameEmail = db.Users.Where(u => u.Email == user.Email).First();
            if (ModelState.IsValid)
            {
                if(UserWithTheSameEmail == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("ListUsers");
                }
            }

            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", user.RoleId);
            return RedirectToAction("ListUsers");
        }

        public ActionResult DeleteUser(int? UserId)
        {
            if (UserId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(UserId);
            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                List<UserProject> userProjects = db.UserProjects.Where(up => up.UserId == UserId).ToList();
                List<Request> requests = db.Requests.Where(r => r.ReceiverId == UserId || r.SenderId == UserId).ToList();
                foreach(UserProject userProject in userProjects)
                {
                    db.UserProjects.Remove(userProject);
                }
                foreach (Request request in requests)
                {
                    db.Requests.Remove(request);
                }
                db.Users.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("ListUsers");
        }

        public ActionResult ListProjects()
        {
            return View(db.Projects.ToList());
        }

        public ActionResult DeleteProject(int ProjectId)
        {
            Project project = db.Projects.Find(ProjectId);
            List<UserProject> userProjects = db.UserProjects.Where(up => up.ProjectId == ProjectId).ToList();
            List<Request> requests = db.Requests.Where(r => r.ProjectId == ProjectId).ToList();
            foreach (UserProject userProject in userProjects)
            {
                db.UserProjects.Remove(userProject);
            }
            foreach (Request request in requests)
            {
                db.Requests.Remove(request);
            }
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("ListProjects");
        }

    }
}