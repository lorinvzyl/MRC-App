using MRC_App.Models;
using MRC_App.Services;
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
            Controls.Collection<Location> locationsCollection = RestService.GetChurchLocations().Result;

            foreach (var location in locationsCollection)
            {
                locations.Add(location);
            }
        }
    }
}
