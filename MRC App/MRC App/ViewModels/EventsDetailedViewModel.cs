using MRC_App.Models;
using MRC_App.Services;
using MRC_App.Views;
using Newtonsoft.Json;
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
    [QueryProperty(nameof(Param), nameof(Param))]
    public class EventsDetailedViewModel : BaseViewModel
    {
        public ICommand TapCommand;

        public EventsDetailedViewModel()
        {
            TapCommand = new Command(OnRSVPClicked);
            Nav = new ObservableCollection<Navigation>();

            AddNavData();
        }

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

        private static Event selectedEvent;
        public Event SelectedEvent
        {
            get => selectedEvent;
            set
            {
                selectedEvent = value;
                OnPropertyChanged();
            }
        }

        private void AddNavData()
        {
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

        private bool isVisible;
        public bool IsVisible
        {
            get => isVisible;
            set
            {
                isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        private bool locationIsVisible;
        public bool LocationIsVisible
        {
            get => locationIsVisible;
            set
            {
                locationIsVisible = value;
                OnPropertyChanged(nameof(LocationIsVisible));
            }
        }

        private void PerformOperation(string paramStr)
        {
            var param = JsonConvert.DeserializeObject<Event>(paramStr);
            FormattedDate = param.RSVPCloseDate.ToString().Substring(0,10);
            SelectedEvent = param;
        }

        public ICommand LocationCommand => new Command(OnLocationClicked);
        private async void OnLocationClicked(object obj)
        {
            var location = SelectedEvent.Venue;
            location.Replace(" ", "%20");
            location.Replace(",", "%2C");

            FormattedLocation = location;

            var supportsWaze = await Launcher.CanOpenAsync("https://waze.com/ul");
            var supportsGoogleMaps = await Launcher.CanOpenAsync("https://www.google.com/maps");
            if (supportsWaze && supportsGoogleMaps)
            {
                LocationIsVisible = true;
            }
            else if (supportsWaze)
                await Launcher.OpenAsync($"https://waze.com/ul?q={FormattedLocation}&navigate=yes");
            else if (supportsGoogleMaps)
                await Launcher.OpenAsync($"https://www.google.com/maps/dir/?api=1&destintation={FormattedLocation}");
            else
            {
                Uri uri = new Uri($"https://waze.com/ul?q={SelectedEvent.Venue}&navigate=yes");
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
        }

        private static string formattedDate;
        public string FormattedDate
        {
            get { return formattedDate; }
            set
            {
                formattedDate = value;
                OnPropertyChanged(nameof(FormattedDate));
            }
        }

        private string formattedLocation;
        public string FormattedLocation
        {
            get { return formattedLocation; }
            set
            {
                formattedLocation = value;
                OnPropertyChanged(nameof(FormattedLocation));
            }
        }

        public async void PopupItemSelected(Navigation navigation)
        {
            LocationIsVisible = false;

            switch (navigation.Title)
            {
                case "Google Maps":
                    Device.BeginInvokeOnMainThread(async () => await Launcher.OpenAsync($"https://www.google.com/maps/dir/?api=1&destintation={FormattedLocation}"));
                    break;
                case "Waze":
                    Device.BeginInvokeOnMainThread(async () => await Launcher.OpenAsync($"https://waze.com/ul?q={FormattedLocation}&navigate=yes"));
                    break;
            }
        }

        private async void OnRSVPClicked(object obj)
        {
            IsVisible = true;
            //check if user already attended
            var id = Int32.Parse(SecureStorage.GetAsync("Id").Result);
            var userEvent = await RestService.GetUserEvent(SelectedEvent.Id, id);

            if(userEvent != null)
            {
                //if yes, update event
                Event _event = new Event()
                {
                    EventName = SelectedEvent.EventName,
                    EventDescription = SelectedEvent.EventDescription,
                    EventDate = SelectedEvent.EventDate,
                    Id = SelectedEvent.Id,
                    RSVPCloseDate = SelectedEvent.RSVPCloseDate,
                    SpacesAvailable = SelectedEvent.SpacesAvailable - 1,
                    SpacesTaken = SelectedEvent.SpacesTaken + 1,
                    Venue = SelectedEvent.Venue,
                };

                UserEvent userEvent1 = new UserEvent()
                {
                    UserEmail = SecureStorage.GetAsync("Email").Result,
                    EventId = SelectedEvent.Id,
                    isAttended = false
                };

                var result = await RestService.Attend(userEvent1);
                var response = await RestService.UpdateEvent(_event.Id, _event);
                

                IsVisible = false;

                if (!response)
                {
                    Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "Ok"));
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Success", $"You RSVP'd for {_event.EventName}", "Ok"));
                }
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Error", "You already RSVP'd for this event", "Ok"));
            }
        }

    }
}
