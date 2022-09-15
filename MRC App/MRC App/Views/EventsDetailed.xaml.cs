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

    }
}