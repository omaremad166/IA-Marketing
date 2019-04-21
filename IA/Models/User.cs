using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public byte[] Photo { get; set; }
        public string Description { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<UserProject> UserProjects { get; set; }

        public virtual ICollection<Request> Requests { get; set; }


        public string GetUserName()
        {
            return this.FirstName + ' ' + this.LastName;
        }

    }
}