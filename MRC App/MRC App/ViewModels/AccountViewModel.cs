using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using MRC_App.Services;
using MRC_App.Models;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using MRC_App.Views;

namespace MRC_App.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public AccountViewModel()
        {
            ToggleCommand = new Command<bool>(async x => await Toggled(x).ConfigureAwait(false));
            
        }

        public ICommand ToggleCommand { get; }
        public ICommand DelUser => new Command(AccountDelete);
        public ICommand ResUser => new Command(AccountResetPassword);

        public async Task Toggled(bool newValue)
        {
            await UpdateNewsletter(newValue);
        }

        public async Task UpdateNewsletter(bool isNewsletter)
        {
            await SecureStorage.SetAsync("Newsletter", isNewsletter.ToString());
            UpdateUser();
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

        private string nPassword;
        public string NPassword
        {
            get { return nPassword; }
            set
            {
                nPassword = value;
                OnPropertyChanged(nameof(NPassword));
            }
        }

        private string cnPassword;
        public string CNPassword
        {
            get { return cnPassword; }
            set
            {
                cnPassword = value;
                OnPropertyChanged(nameof(CNPassword));
            }
        }

        private bool passwordIsValid;
        public bool PasswordIsValid
        {
            get { return passwordIsValid; }
            set
            {
                passwordIsValid = value;
                OnPropertyChanged(nameof(PasswordIsValid));
            }
        }

        private async void AccountResetPassword()
        {
            ResetIsVisible = false;
            IsVisible = true;

            string password = Password;
            string newPassword = NPassword;
            string confirmNewPassword = CNPassword;

            //clear passwords from storage
            Password = String.Empty;
            NPassword = String.Empty;
            CNPassword = String.Empty;

            //login user here
            User user = new User()
            {
                Password = password,
                Email = SecureStorage.GetAsync("Email").Result.ToLower()
            };

            var response = await RestService.LoginUser(user);

            if (response && newPassword == confirmNewPassword && PasswordIsValid)
            {
                user.Id = Int32.Parse(SecureStorage.GetAsync("Id").Result);
                user.DateOfBirth = DateTime.Parse(SecureStorage.GetAsync("Birth").Result);
                user.isNewsletter = Boolean.Parse(SecureStorage.GetAsync("Newsletter").Result);
                user.Name = SecureStorage.GetAsync("Name").Result;
                user.Surname = SecureStorage.GetAsync("Surname").Result;

                var result = await RestService.UpdateUser(user.Id, user);
                if (result)
                {
                    Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Success", "Password changed", "Ok"));
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "Ok"));
                }
                
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "Ok"));
            }

            IsVisible = false;
        }

        public async void AccountDelete()
        {
            DeleteIsVisible = false;
            IsVisible = true;

            string password = Password;
            Password = String.Empty;

            if (!String.IsNullOrEmpty(password))
            {
                //Login user here
                User user = new User()
                {
                    Password = password,
                    Email = SecureStorage.GetAsync("Email").Result.ToLower()
                };

                var response = await RestService.LoginUser(user);

                //if true, do delete
                if (response)
                {
                    var result = await RestService.DeleteUser(user.Email);
                    if (result)
                    {
                        //sign user out
                        await Task.Run(() =>
                        {
                            SecureStorage.RemoveAll();
                            Device.BeginInvokeOnMainThread(async () => await Shell.Current.GoToAsync($"//{nameof(LoginPage)}"));
                        });
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "Ok"));
                    }
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "Ok"));
                }
            }

            IsVisible = false;
        }

        private bool resetIsVisible;
        public bool ResetIsVisible
        {
            get => resetIsVisible;
            set
            {
                resetIsVisible = value;
                OnPropertyChanged(nameof(ResetIsVisible));
            }
        }

        private bool deleteIsVisible;
        public bool DeleteIsVisible
        {
            get { return deleteIsVisible; }
            set
            {
                deleteIsVisible = value;
                OnPropertyChanged(nameof(DeleteIsVisible));
            }
        }

        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public async Task UpdateUser()
        {
            User user = new User(){
                Id = Int32.Parse(SecureStorage.GetAsync("Id").Result),
                Name = SecureStorage.GetAsync("Name").Result,
                Surname = SecureStorage.GetAsync("Surname").Result,
                Email = SecureStorage.GetAsync("Email").Result,
                DateOfBirth = DateTime.Parse(SecureStorage.GetAsync("Birth").Result),
                isNewsletter = Boolean.Parse(SecureStorage.GetAsync("Newsletter").Result)
            };

            var update = await RestService.UpdateUser(user.Id, user);

            if(update)
            {
                await UpdateData();
            }
        }

        public async Task UpdateData()
        {
            Name = SecureStorage.GetAsync("Name").Result;
            Surname = SecureStorage.GetAsync("Surname").Result;
            Email = SecureStorage.GetAsync("Email").Result;
            DateOfBirth = SecureStorage.GetAsync("Birth").Result.Substring(0,10);
        }

        private static string name;
        private static string surname;
        private static string dateOfBirth;
        private static string email;
        private static bool isNewsletter;

        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }
        private string profilePicURL;
        public string ProfilePicURL
        {
            get { return profilePicURL; }
            set
            {
                profilePicURL = value;
                OnPropertyChanged(nameof(ProfilePicURL));
            }
        }

        public bool IsNewsletter
        {
            get { return isNewsletter; }
            set
            {
                isNewsletter = value;
                OnPropertyChanged(nameof(IsNewsletter));
            }
        }
    }
}

