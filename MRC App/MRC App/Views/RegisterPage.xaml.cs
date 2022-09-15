using MRC_App.Models;
using MRC_App.Services;
using MRC_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        RegisterViewModel viewModel;
        public RegisterPage()
        {
            InitializeComponent();
            viewModel = new RegisterViewModel();
            BindingContext = viewModel;
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            User user = new User()
            {
                Name = FName.Text,
                Surname = LName.Text,
                Email = EmailEntry.Text,
                DateOfBirth = DateTime.Parse(Birth.Text),
                Password = PasswordEntry.Text,
                Id = 1
            };
            await viewModel.RegisterUser(user);
        }
    }
}