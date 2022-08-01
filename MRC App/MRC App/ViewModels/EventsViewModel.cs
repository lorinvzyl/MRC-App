using MRC_App.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public EventCollection Events { get; set; }

        public CultureInfo Culture => new CultureInfo("en-US");
    }
}
