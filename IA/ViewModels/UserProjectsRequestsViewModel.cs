using IA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IA.ViewModels
{
    public class UserProjectsRequestsViewModel
    {
        public User User { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}