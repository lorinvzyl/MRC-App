using MRC_App.Controls;
using MRC_App.Models;
using MRC_App.ViewModels;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPage : ContentPage
    {
        public LocationPage()
        {
            InitializeComponent();
        }

        async void CollectionView_ItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.CurrentSelection.FirstOrDefault() is Models.Location location))
                return;

            LocationViewModel viewModel = new LocationViewModel();

            var supportsWaze = await Launcher.CanOpenAsync("https://waze.com/ul");
            var supportsGoogleMaps = await Launcher.CanOpenAsync("comgooglemaps://");
            if (supportsWaze && supportsGoogleMaps)
            {
                viewModel.IsVisible = true;
                viewModel.Location = location;
                this.BindingContext = viewModel;
            }
            else if (supportsWaze)
                await Launcher.OpenAsync($"https://waze.com/ul?q={location.MapsURL}&navigate=yes");
            else if(supportsGoogleMaps)
                await Launcher.OpenAsync($"comgooglemaps://?daddr={location.MapsURL}"); //need to add comgooglemaps before it can be valid. Can't seem to find how to do this.
            else
            {
                Uri uri = new Uri($"https://waze.com/ul?q={location.MapsURL}&navigate=yes");
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
        }

        private void Location_Popup(object sender, SelectionChangedEventArgs e)
        {
            var navigation = e.CurrentSelection.FirstOrDefault();
            if (navigation != null && navigation is Models.Navigation nav)
            {
                LocationViewModel locationViewModel = new LocationViewModel();
                locationViewModel.PopupItemSelected(nav);
                this.BindingContext = locationViewModel;
            }
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            LocationViewModel viewModel = new LocationViewModel();

            viewModel.IsVisible = false;

            this.BindingContext = viewModel;
        }
    }
}