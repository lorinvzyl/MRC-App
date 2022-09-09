using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Acr.UserDialogs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MRC_App.ViewModels;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        private readonly AccountViewModel _viewModel; 

        public AccountPage()
        {
            InitializeComponent();

            // initializing the viewModel varible
            BindingContext = _viewModel = new AccountViewModel();

        }

        // creating the switch_Ontoggled properties. 
        private async void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            if (_viewModel.EnableEvents)
            {
                await UserDialogs.Instance.AlertAsync($"New value: {e.Value}", "Switch toggled(Event)").ConfigureAwait(false);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        

        private void ChangeAvatarBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void RemoveAvatarBtn_Clicked(object sender, EventArgs e)
        {

        }

        /*
        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccessibilityTestPage());
        }
        */


    }
}