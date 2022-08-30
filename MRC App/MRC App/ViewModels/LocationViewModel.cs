using MRC_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MRC_App.ViewModels
{
    public class LocationViewModel : BaseViewModel
    {
        private ObservableCollection<Locations> Locations;
        public ObservableCollection<Locations> locations
        {
            get { return Locations; }
            set { Locations = value; }
        }

        public LocationViewModel()
        { 
            locations = new ObservableCollection<Locations>();
            AddData();
        }

        private void AddData()
        {
            locations.Add(new Locations
            {
                Id = 0,
                Name = "Church Location 1",
                Location = "8 Kristal Crescent",
                PastorName = "John"
            });
            locations.Add(new Locations
            {
                Id = 1,
                Name = "Church Location 2",
                Location = "8 Kristal Crescent",
                PastorName = "Bob"
            });
            locations.Add(new Locations
            {
                Id = 2,
                Name = "Church Location 3",
                Location = "8 Kristal Crescent",
                PastorName = "Kirby"
            });
        }
    }
}
