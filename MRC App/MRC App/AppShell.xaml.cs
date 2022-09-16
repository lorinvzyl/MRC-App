using MRC_App.ViewModels;
using MRC_App.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MRC_App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("AboutPage", typeof(AboutPage));
            Routing.RegisterRoute("AccountPage", typeof(AccountPage));
            Routing.RegisterRoute("BlogDetailed", typeof(BlogDetailed));
            Routing.RegisterRoute("BlogPage", typeof(BlogPage));
            Routing.RegisterRoute("DonatePage", typeof(DonatePage));
            Routing.RegisterRoute("EventsPage", typeof(EventsPage));
            Routing.RegisterRoute("EventsDetailed", typeof(EventsDetailed));
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("QRPage", typeof(QRPage));
            Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
            Routing.RegisterRoute("LocationPage", typeof(LocationPage));
        }

        private async void Logout_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        public void SetUsername()
        {
            var name = SecureStorage.GetAsync("Name").Result;
            var surname = SecureStorage.GetAsync("Surname").Result;
            
            Username.Add(new string($"{name} {surname}"));
        }

        private async void Account_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(AccountPage)}");
            Shell.Current.FlyoutIsPresented = false;
        }

        private ObservableCollection<string> username;
        public ObservableCollection<string> Username
        {
            get { return username; }
            set 
            { 
                username = value; 
                OnPropertyChanged("Username");
            }
        }
    }
}
