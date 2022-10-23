using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MRC_App.ViewModels;
using Xamarin.Essentials;
using MRC_App.Models;
using MRC_App.Services;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
        }

        private async void DeleteAccountLblGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            AccountViewModel viewModel = new AccountViewModel();

            viewModel.DeleteIsVisible = true;

            this.BindingContext = viewModel;
        }

        private async void ResetPasswordLblGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            AccountViewModel viewModel = new AccountViewModel();

            viewModel.ResetIsVisible = true;

            this.BindingContext = viewModel;
        }

        private void EditName_Tapped(object sender, EventArgs e)
        {
            var name = SecureStorage.GetAsync("Name").Result;
            var edit = new AccountEdit("First Name:", name);
            Shell.Current.Navigation.PushAsync(edit);
        }

        private void EditSurname_Tapped(object sender, EventArgs e)
        {
            var surname = SecureStorage.GetAsync("Surname").Result;
            var edit = new AccountEdit("Last Name:", surname);
            Shell.Current.Navigation.PushAsync(edit);
        }

        private void EditEmail_Tapped(object sender, EventArgs e)
        {
            var email = SecureStorage.GetAsync("Email").Result;
            var edit = new AccountEdit("Email:", email);
            Shell.Current.Navigation.PushAsync(edit);
        }

        private void EditBirthday_Tapped(object sender, EventArgs e)
        {
            var birthday = SecureStorage.GetAsync("Birth").Result;
            var edit = new AccountEdit("Birthday:", birthday.Substring(0,10));
            Shell.Current.Navigation.PushAsync(edit);
        }

        protected override void OnAppearing()
        {
            AccountViewModel viewModel = new AccountViewModel();
            viewModel.UpdateData();

            this.BindingContext = viewModel;
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            AccountViewModel viewModel = new AccountViewModel();

            viewModel.ResetIsVisible = false;
            viewModel.DeleteIsVisible = false;

            this.BindingContext = viewModel;
        }
    }
}