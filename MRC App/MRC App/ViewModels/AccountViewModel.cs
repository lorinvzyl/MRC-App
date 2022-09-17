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
            Name = new ObservableCollection<string>();
            Surname = new ObservableCollection<string>();
            Email = new ObservableCollection<string>();
            DateOfBirth = new ObservableCollection<string>();

            Name.Add(new string(SecureStorage.GetAsync("Name").Result));
            Surname.Add(new string(SecureStorage.GetAsync("Surname").Result));
            Email.Add(new string(SecureStorage.GetAsync("Email").Result));
            DateOfBirth.Add(new string(SecureStorage.GetAsync("Birth").Result));

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

        public async Task<bool> UpdateUser(string email, string name, string surname, DateTime dateOfBirth, bool isNewsletter)
        {
            if (email == null || name == null || surname == null || dateOfBirth == null)
                return false;

            User user = new User(){
                Name = name,
                Email = email,
                Surname = surname,
                DateOfBirth = dateOfBirth,
                isNewsletter = isNewsletter
            };

            var update = await RestService.UpdateUser(email, user);

            return update;
        }

        private ObservableCollection<string> name;
        private ObservableCollection<string> surname;
        private ObservableCollection<string> dateOfBirth;
        private ObservableCollection<string> email;

        public ObservableCollection<string> Name
        {
            get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<string> Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public ObservableCollection<string> Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public ObservableCollection<string> DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }
    }
}

