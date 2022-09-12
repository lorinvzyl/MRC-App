using MRC_App.Models;
using MRC_App.Services;
using MRC_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            User user = new User()
            {
                Name = FName.Text,
                Surname = LName.Text,
                Email = Email.Text,
                DateOfBirth = DateTime.Parse(Birth.Text),
                Password = Password.Text
            };
            var registered = false;

            if(user != null)
                registered = await RestService.RegisterUser(user);

            user.Password = null;

            if (registered)
            {
                RegisterViewModel viewModel = new RegisterViewModel();
                viewModel.RegisterCommand.Execute(viewModel);
            }
        }
    }
}