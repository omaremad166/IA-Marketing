using IA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IA.ViewModels
{
    public class ProjectUsersViewModel
    {
        public Project Project { get; set; }
        public ICollection<User> Users { get; set; }
        public Request Request { get; set; }
    }
}