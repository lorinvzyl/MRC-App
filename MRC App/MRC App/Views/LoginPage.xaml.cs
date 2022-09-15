using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MRC_App.ViewModels;
using MRC_App.Models;
using MRC_App.Services;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;
        public LoginPage()
        {
            InitializeComponent();
            viewModel = new LoginViewModel();
            BindingContext = viewModel;
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            User user = new User()
            {
                Email = EmailEntry.Text,
                Password = PasswordEntry.Text
            };

            await viewModel.LoginUser(user);
        }
    }
}