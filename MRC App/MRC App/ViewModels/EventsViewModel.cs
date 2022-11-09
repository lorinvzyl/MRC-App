using MRC_App.Models;
using MRC_App.Services;
using MRC_App.Views;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Plugin.Calendar.Models;

namespace MRC_App.ViewModels
{
    public class EventsViewModel : BaseViewModel
    {
        public ICommand EventSelectedCommand => new Command(async (item) => await ExecuteEventSelectedCommand(item));
        public ICommand TodayCommand => new Command(() =>
        {
            Year = DateTime.Today.Year;
            Month = DateTime.Today.Month;
        });

        public DateTime Today = DateTime.Today;
        public EventsViewModel()
        {
            IsVisible = true;

            Event = new EventCollection();

            GenerateEvents();
            
        }

        public EventsViewModel(bool isTest)
        {
            Event = new EventCollection();
        }

        public EventCollection Event { get; set; }

        async Task GenerateEvents()
        {
            IEnumerable<Event> _event = await RestService.GetEvents();

            foreach (var item in _event)
            {
                Event.Add(item.EventDate, new List<Event>(GenerateEvent(item)));
            }

            IsVisible = false;
        }

        public IEnumerable<Event> GenerateEvent(Event item)
        {
            return Enumerable.Range(0, 1).Select(e => new Event
            {
                Id = item.Id,
                EventName = item.EventName,
                EventDescription = item.EventDescription,
                SpacesAvailable = item.SpacesAvailable,
                SpacesTaken = item.SpacesTaken,
                RSVPCloseDate = item.RSVPCloseDate,
                EventDate = item.EventDate,
                Venue = item.Venue
            });
        }

        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }


        private int _year;
        private int _month;
        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public int Month
        {
            get => _month;
            set
            {
                _month = value;
                OnPropertyChanged(nameof(Month));
            }
        }

        private DateTime _minimumDate = DateTime.Today.AddMonths(-5);
        public DateTime MinimumDate
        {
            get => _minimumDate;
            set
            {
                _minimumDate = value;
                OnPropertyChanged(nameof(MinimumDate));
            }
        }

        private DateTime _maximumDate = DateTime.Today.AddMonths(5);
        public DateTime MaximumDate
        {
            get => _maximumDate;
            set
            {
                _maximumDate = value;
                OnPropertyChanged(nameof(MaximumDate));
            }
        }

        private async Task ExecuteEventSelectedCommand(object item)
        {
            if(item is Event)
            {
                var jsonStr = JsonConvert.SerializeObject(item);
                await Shell.Current.GoToAsync($"{nameof(EventsDetailed)}?Param={jsonStr}");
            }
        }
    }
}
