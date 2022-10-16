using MRC_App.Models;
using MRC_App.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace MRC_App.Controls
{
    public partial class LocationPopUp : Rg.Plugins.Popup.Pages.PopupPage
    {
        private ObservableRangeCollection<Navigation> nav;
        public ObservableRangeCollection<Navigation> Nav
        {
            get { return nav; }
            set 
            { 
                nav = value;
            }
        }
        public LocationPopUp()
        {
            InitializeComponent();

            Nav = new ObservableRangeCollection<Navigation>();
            InitialiseNav();
        }

        public void InitialiseNav()
        {
            Navigation navigation = new Navigation()
            {
                Icon = "&#xf83f;",
                Title = "Waze"
            };
            Navigation navigation1 = new Navigation()
            {
                Icon = "&#xf1a0;",
                Title = "Google Maps"
            };

            Nav.Add(navigation1);
            Nav.Add(navigation);
        }

        async void ItemSelected_CollectionView(object sender, SelectedItemChangedEventArgs e)
        {
            var navigation = e.SelectedItem as Navigation;
            if(navigation != null)
            {
                LocationViewModel locationViewModel = new LocationViewModel();
                //locationViewModel.PopupItemSelected(navigation);
            }
        }

        private async void OnClose(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}