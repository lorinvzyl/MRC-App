using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MRC_App.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public int SpacesAvailable { get; set; }
        public int SpacesTaken { get; set; }
        public string Venue { get; set; }
        public DateTime RSVPCloseDate { get; set; }
        public DateTime EventDate { get; set; }


    }
}
