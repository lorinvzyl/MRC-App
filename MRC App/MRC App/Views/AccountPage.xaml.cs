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

        private async void DeleteAccountLblGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Warning!", "Are you sure you want to delete your account?", "Yes", "No");
        }
        /*
       private async void Button_OnClicked(object sender, EventArgs e)
       {
           await Navigation.PushAsync(new AccessibilityTestPage());
       }
       */

        private async void ResetPasswordLblGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Warning!", "Are you sure you want to reset your account pasword?", "Yes", "No");
        }

        private async void EditName_Tapped(object sender, EventArgs e)
        {
        }

        private async void EditSurname_Tapped(object sender, EventArgs e)
        {
        }

        private async void EditEmail_Tapped(object sender, EventArgs e)
        {
        }

        private async void EditBirthday_Tapped(object sender, EventArgs e)
        {
        }

        private void ChangeAvatarBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void RemoveAvatarBtn_Clicked(object sender, EventArgs e)
        {

        }

       


    }
}