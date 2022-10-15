using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MRC_App.Views;
using System.Text.RegularExpressions;
using MRC_App.Models;
using System.Threading.Tasks;
using MRC_App.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using System.Windows.Input;

namespace MRC_App.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {

        public ICommand RegisterCommand => new Command(OnRegisterClicked);
        public ICommand ButtonCommand => new AsyncCommand(RegisterUser);
        public ICommand EntryUnfocus => new AsyncCommand(OnEntryUnfocus);
        public RegisterViewModel()
        {
        }

        public async Task OnEntryUnfocus()
        {
            if (!EmailValid || !PasswordValid || !BirthValid || String.IsNullOrEmpty(Birth) || String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(Email))
                IsEnabled = false;
            else
                IsEnabled = true;
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

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}"); /*Needs to have the // prefix added for allowing for a different navigation stack. Gives errors otherwise.*/
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

        private bool birthValid;
        public bool BirthValid
        {
            get { return birthValid; }
            set
            {
                birthValid = value;
                OnPropertyChanged(nameof(BirthValid));
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

        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
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

        private string birth;
        public string Birth
        {
            get { return birth; }
            set
            {
                birth = value;
                OnPropertyChanged(nameof(Birth));
            }
        }


        private string error;
        public string Error
        {
            get => error;
            set
            {
                SetProperty(ref error, value);
            }
        }
        private async Task RegisterUser()
        {
            if (Name == null || Surname == null || Email == null || Birth == null || Password == null)
            {
                Error = "Invalid input";
                return;
            }

            User user = new User()
            {
                Name = Name,
                Surname = Surname,
                Email = Email,
                DateOfBirth = DateTime.Parse(Birth),
                Password = Password,
                Id = 1
            };

            var registration = await RestService.RegisterUser(user);

            if (registration)
                RegisterCommand.Execute(registration);
        }
    }
}
