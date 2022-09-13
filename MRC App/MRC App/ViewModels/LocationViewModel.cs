using MRC_App.Models;
using MRC_App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MRC_App.ViewModels
{
    public class LocationViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Location> locations;
        public ObservableRangeCollection<Location> Locations
        {
            get { return locations; }
            set { locations = value; }
        }

        public AsyncCommand RefreshCommand { get; }

        public LocationViewModel()
        { 
            Locations = new ObservableRangeCollection<Location>();
            RefreshCommand = new AsyncCommand(Refresh);

            AddData();
        }

        async Task Refresh()
        {
            IsBusy = true;

            Locations.Clear();

            var locations = await RestService.GetChurchLocations();

            Locations.AddRange(locations);

            IsBusy = false;
        }

        async Task AddData()
        {
            var locations = await RestService.GetChurchLocations();
            Locations.AddRange(locations);
        }
    }
}
