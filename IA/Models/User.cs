using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please Enter First Name e.g. John")]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name e.g. John")]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public byte[] Photo { get; set; }
        public string Description { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<UserProject> UserProjects { get; set; }

        [InverseProperty("Sender")]
        public virtual ICollection<Request> RequestsSenders { get; set; }
        [InverseProperty("Receiver")]
        public virtual ICollection<Request> RequestsReceivers { get; set; }


        public string GetUserName()
        {
            return this.FirstName + ' ' + this.LastName;
        }

    }
}