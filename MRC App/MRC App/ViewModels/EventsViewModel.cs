using MRC_App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Plugin.Calendar.Models;

namespace MRC_App.ViewModels
{
    public class EventsViewModel : BaseViewModel
    {
        public EventsViewModel()
        {
            
        }

        public ICommand TodayCommand => new Command(() =>
        {
            Year = DateTime.Today.Year;
            Month = DateTime.Today.Month;
        });

        public ICommand EventSelectedCommand => new Command(async (item) => await ExecuteEventSelectedCommand(item));

        private async Task ExecuteEventSelectedCommand(object item)
        {  
            throw new NotImplementedException();
        }

        public EventCollection Events { get; set; }

        private int _month = DateTime.Today.Month;

        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        private int _year = DateTime.Today.Year;
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        private DateTime? _selectedDate = DateTime.Today;
        public DateTime? SelectedDate
        {
            get { return _selectedDate; }
            set { _selectedDate = value; }
        }
    }
}
