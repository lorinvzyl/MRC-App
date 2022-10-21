using MRC_App.Controls;
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

            var supportsWaze = await Launcher.CanOpenAsync("https://waze.com/ul");
            var supportsGoogleMaps = await Launcher.CanOpenAsync("comgooglemaps://");
            if (supportsWaze && supportsGoogleMaps)
            {
                var action = await DisplayActionSheet("Open with", "Cancel", null, "Google Maps", "Waze");
                switch (action)
                {
                    case "Google Maps":
                        await Launcher.OpenAsync($"comgooglemaps://?daddr={location.MapsURL}");
                        break;
                    case "Waze":
                        await Launcher.OpenAsync($"https://waze.com/ul?q={location.MapsURL}&navigate=yes");
                        break;

                }
            }
            else if (supportsWaze)
                await Launcher.OpenAsync($"https://waze.com/ul?q={location.MapsURL}&navigate=yes");
            else if(supportsGoogleMaps)
                await Launcher.OpenAsync($"comgooglemaps://?daddr={location.MapsURL}");
            else
            {
                Uri uri = new Uri($"https://waze.com/ul?q={location.MapsURL}&navigate=yes");
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
        }
    }
}