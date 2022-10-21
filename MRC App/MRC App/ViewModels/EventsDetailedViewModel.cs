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

        private Event selectedEvent;
        public Event SelectedEvent
        {
            get => selectedEvent;
            set
            {
                selectedEvent = value;
                OnPropertyChanged();
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

        private void PerformOperation(string paramStr)
        {
            var param = JsonConvert.DeserializeObject<Event>(paramStr);
            param.RSVPCloseDate = DateTime.Parse(param.RSVPCloseDate.ToString().Substring(0,10));
            SelectedEvent = param;
        }

        public ICommand LocationCommand => new Command(OnLocationClicked);
        private async void OnLocationClicked(object obj)
        {
            var supportsWaze = await Launcher.CanOpenAsync("https://waze.com/ul");
            var supportsGoogleMaps = await Launcher.CanOpenAsync("comgooglemaps://");
            if (supportsWaze && supportsGoogleMaps)
            {
                EventsDetailed eventsDetailed = new EventsDetailed();
                eventsDetailed.ActionSheet(SelectedEvent.Venue);
            }
            else if (supportsWaze)
                await Launcher.OpenAsync($"https://waze.com/ul?q={SelectedEvent.Venue}&navigate=yes");
            else if (supportsGoogleMaps)
                await Launcher.OpenAsync($"comgooglemaps://?daddr={SelectedEvent.Venue}");
            else
            {
                Uri uri = new Uri($"https://waze.com/ul?q={SelectedEvent.Venue}&navigate=yes");
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
        }

        private async void OnRSVPClicked(object obj)
        {
            IsVisible = true;
            //check if user already attended


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
               
            var response = await RestService.UpdateEvent(_event.Id, _event);

            IsVisible = false;

            if(!response)
            {
                Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Error", "Could not RSVP", "Ok"));
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Success", $"You RSVP'd for {_event.EventName}", "Ok"));
            }
        }

    }
}
