using MRC_App.ViewModels;
using MRC_App.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MRC_App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void Logout_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void Account_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AccountPage");
        }
    }
}
