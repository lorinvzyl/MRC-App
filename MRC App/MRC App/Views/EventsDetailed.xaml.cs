using MRC_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRC_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsDetailed : ContentPage
    {
        private ObservableCollection<Event> _event;
        public ObservableCollection<Event> Event
        {
            get { return _event; }
            set { _event = value; }
        }

        public EventsDetailed()
        {
            Event = new ObservableCollection<Event>();
            InitializeComponent();
        }
        public EventsDetailed(object item)
        {
            InitializeComponent();
        }

        public async void ActionSheet(string venue)
        {
            var action = await DisplayActionSheet("Open with", "Cancel", null, "Google Maps", "Waze");
            switch (action)
            {
                case "Google Maps":
                    await Launcher.OpenAsync($"comgooglemaps://?daddr={venue}");
                    break;
                case "Waze":
                    await Launcher.OpenAsync($"https://waze.com/ul?q={venue}&navigate=yes");
                    break;

            }
        }
    }
}