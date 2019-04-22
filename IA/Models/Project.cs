﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IA.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserProject> UserProjects { get; set; }

        public int ProjectStateId { get; set; }
        public virtual ProjectState ProjectState { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}