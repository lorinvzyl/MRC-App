using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MRC_App.Views;
using System.Threading.Tasks;
using MRC_App.Models;
using MRC_App.Services;
using Xamarin.Essentials;

namespace MRC_App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        private string error { get; set; }
        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                OnPropertyChanged("Error");
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
            Error = "";
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}"); 
        }

        private bool emailValid { get; set; }

        public bool EmailValid
        {
            get => emailValid;
            set
            {
                emailValid = value;
                OnPropertyChanged();
            }
        }

        public async Task LoginUser(User user)
        {
            Error = "";
            if (user == null)
                return;

            var login = await RestService.LoginUser(user);

            if(login)
            {
                User _user = await RestService.GetUserByEmail(user.Email);
                try
                {
                    await SecureStorage.SetAsync("Id", _user.Id.ToString());
                    await SecureStorage.SetAsync("Name", _user.Name);
                    await SecureStorage.SetAsync("Surname", _user.Surname);
                    await SecureStorage.SetAsync("Email", _user.Email);
                    await SecureStorage.SetAsync("Birth", _user.DateOfBirth.ToString());
                    await SecureStorage.SetAsync("Newsletter", _user.isNewsletter.ToString());
                }
                catch(Exception ex)
                {

                }
                LoginCommand.Execute(user);
            }
            else
            {
                Error = "Incorrect password/email.";
            }
        }
    }
}
