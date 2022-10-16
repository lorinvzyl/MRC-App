﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MRC_App.ViewModels;
using Xamarin.Essentials;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        private readonly AccountViewModel _viewModel = new AccountViewModel(); 

        public AccountPage()
        {
            InitializeComponent();
        }

        private void DeleteAccountLblGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
        }

        private void ResetPasswordLblGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private async void EditName_Tapped(object sender, EventArgs e)
        {
            var name = SecureStorage.GetAsync("Name").Result;
            await Navigation.PushAsync(new AccountEdit("First Name:", name));
        }

        private async void EditSurname_Tapped(object sender, EventArgs e)
        {
            var surname = SecureStorage.GetAsync("Surname").Result;
            await Navigation.PushAsync(new AccountEdit("Last Name:", surname));
        }

        private async void EditEmail_Tapped(object sender, EventArgs e)
        {
            var email = SecureStorage.GetAsync("Email").Result;
            await Navigation.PushAsync(new AccountEdit("Email:", email));
        }

        private async void EditBirthday_Tapped(object sender, EventArgs e)
        {
            var birthday = SecureStorage.GetAsync("Birth").Result;
            await Navigation.PushAsync(new AccountEdit("Birthday:", birthday.Substring(1,10)));
        }

        private void ChangeAvatarBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void RemoveAvatarBtn_Clicked(object sender, EventArgs e)
        {

        }

        protected override void OnAppearing()
        {
            AccountViewModel viewModel = new AccountViewModel();
            viewModel.UpdateData();

            this.BindingContext = viewModel;
        }
    }
}