using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Acr.UserDialogs;

using System.Threading.Tasks;
using MRC_App.Services;
using MRC_App.Models;

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
    }
}

