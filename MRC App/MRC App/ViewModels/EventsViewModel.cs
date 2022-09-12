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
            Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Info", "Loading events", "Ok"));

            List<string> images = new List<string> { "pexels208216.jpg", "pexels6115945.jpg" };

            Event = new EventCollection();

            Controls.Collection<Event> _event = RestService.GetEvents().Result;
            foreach (var item in _event)
            {
                Event.Add(DateTime.Parse(item.Date), new List<Event>(GenerateEvents(item)));
            }
        }

        public EventCollection Event { get; set; }

        private IEnumerable<Event> GenerateEvents(Event item)
        {
            return Enumerable.Range(0, 1).Select(e => new Event
            {
                Id = item.Id,
                Name = $"{item.Name}",
                Description = $"{item.Description}",
                Image = item.Image
            });
        }

        private int _year;
        private int _month;
        public int Year
        {
            get => _year;
            set => SetProperty(ref _year, value);
        }

        public int Month
        {
            get => _month;
            set => SetProperty(ref _month, value);
        }

        private DateTime _minimumDate = new DateTime(2022, 8, 3);
        public DateTime MinimumDate
        {
            get => _minimumDate;
            set => SetProperty(ref _minimumDate, value);
        }

        private DateTime _maximumDate = DateTime.Today.AddMonths(5);
        public DateTime MaximumDate
        {
            get => _maximumDate;
            set => SetProperty(ref _maximumDate, value);
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
