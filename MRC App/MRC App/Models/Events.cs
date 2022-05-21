using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Models
{
    public class Events
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Participants { get; set; }
    }
}
