using MRC_App.Models;
using MRC_App.Services;
using MRC_App.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MRC_App.ViewModels
{
    public class LocationViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Models.Location> locations;
        public ObservableRangeCollection<Models.Location> Locations
        {
            get { return locations; }
            set 
            {
                locations = value;
                OnPropertyChanged(nameof(Locations));
            }
        }

        private ObservableCollection<Navigation> nav;
        public ObservableCollection<Navigation> Nav
        {
            get { return nav; }
            set
            {
                nav = value;
                OnPropertyChanged(nameof(Nav));
            }
        }

        public AsyncCommand RefreshCommand { get; }

        public LocationViewModel()
        { 
            Locations = new ObservableRangeCollection<Models.Location>();
            Nav = new ObservableCollection<Navigation>();
            RefreshCommand = new AsyncCommand(Refresh);

            Task.Run(() =>
            {
                AddData();
            });
        }

        public LocationViewModel(bool isTest)
        {
            Locations = new ObservableRangeCollection<Models.Location>();
            RefreshCommand = new AsyncCommand(Refresh);
        }
        
        public async void PopupItemSelected(Navigation navigation)
        {
            IsVisible = false;

            switch (navigation.Title)
            {
                case "Google Maps":
                    Device.BeginInvokeOnMainThread(async () => await Launcher.OpenAsync($"comgooglemaps://?daddr={Location.MapsURL}"));
                    break;
                case "Waze":
                    Device.BeginInvokeOnMainThread(async () => await Launcher.OpenAsync($"https://waze.com/ul?q={Location.MapsURL}&navigate=yes"));
                    break;
            }
        }

        private static Models.Location location;
        public Models.Location Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        private static bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
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

            Navigation waze = new Navigation()
            {
                Icon = "&#xf83f;",
                Title = "Waze"
            };

            Navigation google = new Navigation()
            {
                Icon = "&#xf1a0;",
                Title = "Google Maps"
            };

            Nav.Add(waze);
            Nav.Add(google);
        }
    }
}
