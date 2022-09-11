using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MRC_App.Models
{
    public class Event
    {
        public int Id { get; set; }
        public List<string> Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

    }
}
