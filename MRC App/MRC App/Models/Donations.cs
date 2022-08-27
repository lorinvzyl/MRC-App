using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Models
{
    internal class Donations
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int Amount { get; set; }
        public string Message { get; set; }
    }
}
