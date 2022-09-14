using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MRC_App.Views;
using System.Threading.Tasks;
using MRC_App.Models;
using MRC_App.Services;
using Plugin.SecureStorage;

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
                CrossSecureStorage.Current.SetValue("Email",user.Email);
                CrossSecureStorage.Current.SetValue("Id", user.Id.ToString());
                CrossSecureStorage.Current.SetValue("Name", user.Name);
                CrossSecureStorage.Current.SetValue("Surname", user.Surname);
                CrossSecureStorage.Current.SetValue("Newsletter", user.isNewsletter.ToString());
                CrossSecureStorage.Current.SetValue("Birth", user.DateOfBirth.ToString());
                CrossSecureStorage.Current.SetValue("Password", user.Password);

                LoginCommand.Execute(user);
            }
            else
            {
                Error = "Incorrect password/email.";
            }
        }
    }
}
