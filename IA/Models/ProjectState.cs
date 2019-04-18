using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IA.Models
{
    public class ProjectState
    {
        public int ProjectStateId { get; set; }
        public string State { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}