using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Changed Locstion variable to church location due to error cause by naming the variable the same name as the class
        public string churchLocation { get; set; }
        public string PastorName { get; set; }
    }
}
