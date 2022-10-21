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
        public LocationPopUp()
        {
            InitializeComponent();

        }

        async void ItemSelected_CollectionView(object sender, SelectedItemChangedEventArgs e)
        {
            var navigation = e.SelectedItem as Navigation;
            if(navigation != null)
            {
                LocationViewModel locationViewModel = new LocationViewModel();
                locationViewModel.PopupItemSelected(navigation);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }

        private async void OnClose(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}