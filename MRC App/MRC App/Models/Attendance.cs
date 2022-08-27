using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public List<User> UserId { get; set; }
    }
}
