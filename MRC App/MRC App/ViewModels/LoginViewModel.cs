using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MRC_App.Views;

namespace MRC_App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }


        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}"); 
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
    }
}
