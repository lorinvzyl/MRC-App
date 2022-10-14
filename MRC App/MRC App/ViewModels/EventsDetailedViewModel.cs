using MRC_App.Models;
using MRC_App.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace MRC_App.ViewModels
{
    [QueryProperty(nameof(Param), nameof(Param))]
    public class EventsDetailedViewModel : BaseViewModel
    {
        public ICommand TapCommand;

        public EventsDetailedViewModel()
        {
            SelectedEvent = new ObservableCollection<Event>();
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

        private ObservableCollection<Event> selectedEvent;
        public ObservableCollection<Event> SelectedEvent
        {
            get => selectedEvent;
            set
            {
                selectedEvent = value;
                OnPropertyChanged();
            }
        }

        private void PerformOperation(string paramStr)
        {
            var param = JsonConvert.DeserializeObject<Event>(paramStr);
            param.RSVPCloseDate = DateTime.Parse(param.RSVPCloseDate.ToString().Substring(0,10));
            SelectedEvent.Add(param);
        }

        private async void OnRSVPClicked(object obj)
        {
            Event _event = new Event();
            foreach(var item in SelectedEvent)
            {
                _event.EventName = item.EventName;
                _event.EventDescription = item.EventDescription;
                _event.EventDate = item.EventDate;
                _event.Id = item.Id;
                _event.RSVPCloseDate = item.RSVPCloseDate;
                _event.SpacesAvailable = item.SpacesAvailable - 1;
                _event.SpacesTaken = item.SpacesTaken + 1;
                _event.Venue = item.Venue;
            }

            var response = await RestService.UpdateEvent(_event.Id, _event);

            if(!response)
            {
                //error pop up
            }
            else
            {
                //success pop up
            }
        }

    }
}
