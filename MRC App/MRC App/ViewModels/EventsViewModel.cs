using MRC_App.Models;
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

            Event = new EventCollection
            {
                [DateTime.Now.AddDays(1)] = new List<Event>(GenerateEvents(1, "Cool", images))
            };
        }

        public EventCollection Event { get; set; }

        private IEnumerable<Event> GenerateEvents(int count, string name, List<string> images)
        {
            return Enumerable.Range(1, count).Select(e => new Event
            {
                Name = $"{name} event{count}",
                Description = $"This is {name} event{count}'s description",
                Image = images
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
