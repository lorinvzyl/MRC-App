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

        private void RSVP_Clicked(object sender, EventArgs e)
        {
            EventsDetailedViewModel viewModel = new EventsDetailedViewModel();

            viewModel.TapCommand.Execute(viewModel);

            this.BindingContext = viewModel;
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            EventsDetailedViewModel viewModel = new EventsDetailedViewModel();

            viewModel.LocationIsVisible = false;

            this.BindingContext = viewModel;
        }

        private void Location_Popup(object sender, SelectionChangedEventArgs e)
        {
            var navigation = e.CurrentSelection.FirstOrDefault();
            if (navigation != null && navigation is Models.Navigation nav)
            {
                EventsDetailedViewModel viewModel = new EventsDetailedViewModel();
                viewModel.PopupItemSelected(nav);
                this.BindingContext = viewModel;
            }
        }
    }
}