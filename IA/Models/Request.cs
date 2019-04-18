using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IA.Models
{
    public class Request
    {
        public int RequestId { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [ForeignKey("Sender")]
        public int? SenderId { get; set; }
        public virtual User Sender { get; set; }

        [ForeignKey("Receiver")]
        public int? ReceiverId { get; set; }
        public virtual User Receiver { get; set; }
    }
}