using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MRC_App.Views;
using System.Text.RegularExpressions;
using MRC_App.Models;
using System.Threading.Tasks;
using MRC_App.Services;

namespace MRC_App.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {

        public Command RegisterCommand { get; }
        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}"); /*Needs to have the // prefix added for allowing for a different navigation stack. Gives errors otherwise.*/
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

        private string error;
        public string Error
        {
            get => error;
            set
            {
                error = value;
                OnPropertyChanged("Error");
            }
        public async Task RegisterUser(User user)
        {
            if (user == null)
                return;

            var registration = await RestService.RegisterUser(user);

            if (registration)
                RegisterCommand.Execute(registration);
        }
    }
}
