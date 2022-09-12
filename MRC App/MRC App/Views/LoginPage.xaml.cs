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
        
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            User user = new User()
            {
                Email = EmailEnt.Text,
                Password = PasswordEnt.Text
            };

            var login = false;

            if (user != null)
                login = await RestService.LoginUser(user);

            if (login)
            {
                LoginViewModel viewModel = new LoginViewModel();
                viewModel.LoginCommand.Execute(viewModel);
            }
        }
    }
}