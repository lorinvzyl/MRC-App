using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Acr.UserDialogs;

using System.Threading.Tasks;
using MRC_App.Services;

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
            var delete = false;
            if (email != null)
                delete = await RestService.DeleteUser(email);

            return delete;
        }
    }
}

