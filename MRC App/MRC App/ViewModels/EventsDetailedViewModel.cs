using MRC_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MRC_App.ViewModels
{
    [QueryProperty(nameof(Param), nameof(Param))]
    public class EventsDetailedViewModel : BaseViewModel
    {
        string param = "";
        public string Param
        {
            get => param;
            set
            {
                param = Uri.UnescapeDataString(value ?? string.Empty);
                OnPropertyChanged();
                PerformOperation(param);
            }
        }

        private int id { get; set; }
        public int Id
        {
            get => id;
            set => id = value;
        }

        private string eventName { get; set; }
        public string EventName
        {
            get { return eventName; }
            set
            {
                eventName = value;
                OnPropertyChanged("EventName");
            }
        }
        private string eventDescription { get; set; }
        public string EventDescription
        {
            get { return eventDescription; }
            set
            {
                eventDescription = value;
                OnPropertyChanged("EventDescription");
            }
        }

        private List<string> eventGallery { get; set; }
        public List<string> EventGallery
        {
            get { return eventGallery; }
            set
            {
                eventGallery = value;
                OnPropertyChanged("EventGallery");
            }
        }

        private int spacesAvailable { get; set; }
        public int SpacesAvailable
        {
            get { return spacesAvailable; }
            set
            {
                spacesAvailable = value;
                OnPropertyChanged("SpacesAvailable");
            }
        }

        private int spacesTaken { get; set; }
        public int SpacesTaken
        {
            get { return spacesTaken; }
            set
            {
                SpacesTaken = value;
                OnPropertyChanged("SpacesTaken");
            }
        }

        private string venue { get; set; }
        public string Venue
        {
            get { return venue; }
            set
            {
                venue = value;
                OnPropertyChanged("Venue");
            }
        }

        private DateTime rsvpCloseDate { get; set; }
        public DateTime RSVPCloseDate
        {
            get { return rsvpCloseDate; }
            set
            {
                rsvpCloseDate = value;
                OnPropertyChanged("RSVPCloseDate");
            }
        }

        private DateTime eventDate { get; set; }
        public DateTime EventDate
        {
            get { return eventDate; }
            set
            {
                EventDate = value;
                OnPropertyChanged("EventDate");
            }
        }

        private void PerformOperation(string paramStr)
        {
            var param = JsonConvert.DeserializeObject<Event>(paramStr);
            EventName = param.EventName;
            EventDescription = param.EventDescription;
            SpacesTaken = param.SpacesTaken;
            SpacesAvailable = param.SpacesAvailable;
            Venue = param.Venue;
            RSVPCloseDate = param.RSVPCloseDate;
            EventDate = param.EventDate;
            Id = param.Id;
        }
    }
}
