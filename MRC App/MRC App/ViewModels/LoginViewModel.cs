using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MRC_App.Views;
using System.Threading.Tasks;
using MRC_App.Models;
using MRC_App.Services;
using Xamarin.Essentials;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MRC_App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand => new Command(OnLoginClicked);
        public ICommand RegisterCommand => new Command(OnRegisterClicked);
        public ICommand ButtonCommand => new AsyncCommand(LoginUser);
        public ICommand EntryUnfocus => new AsyncCommand(OnEntryUnfocus);

        private string error = "";
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
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}"); 
        }

        public async Task OnEntryUnfocus()
        {
            if (!EmailValid || !PasswordValid || String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(Email))
                IsEnabled = false;
            else
                IsEnabled = true;
        }

        private bool emailValid;

        public bool EmailValid
        {
            get => emailValid;
            set
            {
                emailValid = value;
                OnPropertyChanged(nameof(EmailValid));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private bool passwordValid;
        public bool PasswordValid
        {
            get { return passwordValid; }
            set
            {
                passwordValid = value;
                OnPropertyChanged(nameof(PasswordValid));
            }
        }

        private bool isEnabled;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        private async Task LoginUser()
        {
            Error = ""; //reset error message
            if (Email == null || Password == null)
                return;

            User user = new User()
            {
                Email = Email,
                Password = Password,
            };

            var login = await RestService.LoginUser(user);

            if(login)
            {
                var _user = await RestService.GetUserByEmail(user.Email);
                if(_user != null)
                {
                    try
                    {
                        await SecureStorage.SetAsync("Id", _user.Id.ToString());
                        await SecureStorage.SetAsync("Name", _user.Name);
                        await SecureStorage.SetAsync("Surname", _user.Surname);
                        await SecureStorage.SetAsync("Email", _user.Email);
                        await SecureStorage.SetAsync("Birth", _user.DateOfBirth.ToString());
                        await SecureStorage.SetAsync("Newsletter", _user.isNewsletter.ToString());
                        await SecureStorage.SetAsync("ProfileImage", _user.ProfilePicURL);
                    }
                    catch (Exception ex)
                    {

                    }
                }

                LoginCommand.Execute(user);
            }
            else
            {
                Error = "Incorrect password/email";
            }
        }
    }
}
