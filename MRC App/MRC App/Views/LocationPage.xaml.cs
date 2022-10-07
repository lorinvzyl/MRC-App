using MRC_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
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

        async void PopupNavigation(System.Object sender, System.EventArgs e)
        {
            var action = await DisplayActionSheet("Open with", "Cancel", null, "Google Maps", "Waze");
            switch (action)
            {
                case "Google Maps":
                   await Launcher.OpenAsync("http://maps.google.com/?daddr=Reformed%20Church%20Rabie%20Ridge");
                    break;
                case "Waze":
                   await Launcher.OpenAsync("https://waze.com/ul");
                    break;

            }
            //await Launcher.OpenAsync("http://maps.google.com/?daddr=Reformed%20Church%20Rabie%20Ridge");
        }

        async void CollectionView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var location = e.SelectedItem as Models.Location;


            var supportsWaze = await Launcher.CanOpenAsync("https://waze.com/ul");
            var supportsGoogleMaps = await Launcher.CanOpenAsync("comgooglemaps://");

            if (supportsWaze || supportsGoogleMaps)
            {
                //bring pop up
                //use pop up selection to open launcher
                //await Launcher.OpenAsync($"comgooglemaps://?daddr={location.MapsUrl}");
                //await Launcher.OpenAsync($"https://waze.com/ul?q={location.MapsUrl}&navigate=yes");
            }
        }
    }
}