using IA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IA.ViewModels
{
    public class UserProjectsViewModel
    {
        public User User { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}