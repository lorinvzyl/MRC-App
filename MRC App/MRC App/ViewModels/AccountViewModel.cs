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

namespace MRC_App.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public AccountViewModel()
        {
            ToggleCommand = new Command<bool>(async x => await Toggled(x).ConfigureAwait(false));
        }

        public ICommand ToggleCommand { get; }

        public async Task Toggled(bool newValue)
        {
            await UpdateNewsletter(newValue);
        }

        public async Task UpdateNewsletter(bool isNewsletter)
        {
            await SecureStorage.SetAsync("Newsletter", isNewsletter.ToString());
            UpdateUser();
        }

        public async Task<bool> DeleteUser(string email)
        {
            if (email == null)
                return false;

            var delete = await RestService.DeleteUser(email);
            return delete;
        }

        public async Task UpdateUser()
        {
            User user = new User(){
                Id = Int32.Parse(SecureStorage.GetAsync("Id").Result),
                Name = SecureStorage.GetAsync("Name").Result,
                Surname = SecureStorage.GetAsync("Surname").Result,
                Email = SecureStorage.GetAsync("Email").Result,
                DateOfBirth = DateTime.Parse(SecureStorage.GetAsync("Birth").Result),
                isNewsletter = Boolean.Parse(SecureStorage.GetAsync("Newsletter").Result),
                ProfilePicURL = SecureStorage.GetAsync("ProfileImage").Result
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

