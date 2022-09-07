using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MRC_App.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public AccountViewModel()
        {

        }

        private Command toggledCommand;

        public ICommand ToggledCommand
        {
            get
            {
                if (toggledCommand == null)
                {
                    toggledCommand = new Command(Toggled);
                }

                return toggledCommand;
            }
        }

        private void Toggled()
        {
        }
    }
}
