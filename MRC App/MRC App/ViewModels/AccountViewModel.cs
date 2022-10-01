using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Acr.UserDialogs;

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
        public bool EnableCommands { get; set; }
        public bool EnableEvents { get; set; }

        public ICommand ToggleCommand { get; }

        public async Task Toggled(bool newValue)
        {
            if (EnableCommands)
            {
                await UserDialogs.Instance.AlertAsync($"New value: {newValue}", "Switch toggled (Command)").ConfigureAwait(false);
            }
        }

        

        public async Task<bool> DeleteUser(string email)
        {
            if (email == null)
                return false;

            var delete = await RestService.DeleteUser(email);
            return delete;
        }

        public async Task<bool> UpdateUser(int id, string name, string surname, DateTime dateOfBirth, bool isNewsletter)
        {
            //need to update this method
            if (email == null || name == null || surname == null || dateOfBirth == null)
                return false;

            User user = new User(){
                Name = name,
                Email = email,
                Surname = surname,
                DateOfBirth = dateOfBirth,
                isNewsletter = isNewsletter
            };

            var update = await RestService.UpdateUser(id, user);

            return update;
        }

        public async Task UpdateData()
        {
            Name = SecureStorage.GetAsync("Name").Result;
            Surname = SecureStorage.GetAsync("Surname").Result;
            Email = SecureStorage.GetAsync("Email").Result;
            DateOfBirth = SecureStorage.GetAsync("Birth").Result[..10];
        }

        private string name;
        private string surname;
        private string dateOfBirth;
        private string email;

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
    }
}

