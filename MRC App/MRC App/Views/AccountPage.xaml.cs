using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MRC_App.ViewModels;
using Xamarin.Essentials;
using MRC_App.Models;
using MRC_App.Services;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        private readonly AccountViewModel _viewModel = new AccountViewModel(); 

        public AccountPage()
        {
            InitializeComponent();
        }

        private async void DeleteAccountLblGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            string password = await DisplayPromptAsync("Warning!", "Account deletion is permanent.&#10;Please enter your password to delete your account:", "Confirm", "Cancel");

            if(!String.IsNullOrEmpty(password))
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
                        await Task.Run(async () =>
                        {
                            SecureStorage.RemoveAll();
                            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                        });
                    }
                    else
                    {
                        //error
                    }
                }
            }
           
        }

        private async void ResetPasswordLblGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            string currentPassword = String.Empty;
            string newPassword = String.Empty;
            string confirmNewPassword = String.Empty;

            currentPassword = await DisplayPromptAsync("Reset Password", "Please enter your current password:", "Confirm", "Cancel", "Current Password");
            if(!String.IsNullOrEmpty(currentPassword))
            {
                newPassword = await DisplayPromptAsync("Reset Password", "Please enter your new password:", "Confirm", "Cancel");
                if(newPassword != currentPassword && !String.IsNullOrEmpty(newPassword))
                {
                    confirmNewPassword = await DisplayPromptAsync("Reset Password", "Please confirm your new password:", "Confirm", "Cancel");
                }
            }

            //login user here
            if(newPassword == confirmNewPassword)
            {
                User user = new User()
                {
                    Password = currentPassword,
                    Email = SecureStorage.GetAsync("Email").Result.ToLower()
                };

                var response = await RestService.LoginUser(user);

                //update user if valid password entered
                if (response)
                {
                    user.Id = Int32.Parse(SecureStorage.GetAsync("Id").Result);
                    user.DateOfBirth = DateTime.Parse(SecureStorage.GetAsync("Birth").Result);
                    user.isNewsletter = Boolean.Parse(SecureStorage.GetAsync("Newsletter").Result);
                    user.Name = SecureStorage.GetAsync("Name").Result;
                    user.Surname = SecureStorage.GetAsync("Surname").Result;

                    var result = await RestService.UpdateUser(user.Id, user);
                    if (result)
                    {
                        //success
                    }
                    else
                    {
                        //error
                    }
                }
            }
            
        }

        private async void EditName_Tapped(object sender, EventArgs e)
        {
            var name = SecureStorage.GetAsync("Name").Result;
            await Navigation.PushAsync(new AccountEdit("First Name:", name));
        }

        private async void EditSurname_Tapped(object sender, EventArgs e)
        {
            var surname = SecureStorage.GetAsync("Surname").Result;
            await Navigation.PushAsync(new AccountEdit("Last Name:", surname));
        }

        private async void EditEmail_Tapped(object sender, EventArgs e)
        {
            var email = SecureStorage.GetAsync("Email").Result;
            await Navigation.PushAsync(new AccountEdit("Email:", email));
        }

        private async void EditBirthday_Tapped(object sender, EventArgs e)
        {
            var birthday = SecureStorage.GetAsync("Birth").Result;
            await Navigation.PushAsync(new AccountEdit("Birthday:", birthday.Substring(0,10)));
        }

        protected override void OnAppearing()
        {
            AccountViewModel viewModel = new AccountViewModel();
            viewModel.UpdateData();

            this.BindingContext = viewModel;
        }
    }
}