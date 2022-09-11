using MRC_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MRC_App.ViewModels
{
    public class LocationViewModel : BaseViewModel
    {
        private ObservableCollection<Location> Locations;
        public ObservableCollection<Location> locations
        {
            get { return Locations; }
            set { Locations = value; }
        }

        public LocationViewModel()
        { 
            locations = new ObservableCollection<Location>();
            AddData();
        }

        private void AddData()
        {
            locations.Add(new Location
            {
                Id = 0,
                Name = "Church Location 1",
                MapsURL = "http://maps.google.com/?daddr=Reformed+Church+Rabie+Ridge",
                PastorName = "John"
            });
            locations.Add(new Location
            {
                Id = 1,
                Name = "Church Location 2",
                MapsURL = "http://maps.google.com/?daddr=The+English+Reformed+Church",
                PastorName = "Bob"
            });
            locations.Add(new Location
            {
                Id = 2,
                Name = "Church Location 3",
                MapsURL = "http://maps.google.com/?daddr=Uniting+Reformed+Church+In+Southern+Africa",
                PastorName = "Kirby"
            });
        }
    }
}
