using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Models
{
    public class UserEvent
    {
        public string UserEmail { get; set; }
        public int EventId { get; set; }
        public bool isAttended { get; set; }
    }
}
