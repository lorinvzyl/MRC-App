using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public int Amount { get; set; }
        public string Message { get; set; }
    }
}
