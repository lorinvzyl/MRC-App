﻿using MRC_App.Models;
using MRC_App.Services;
using MRC_App.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MRC_App.ViewModels
{
    public class AccountEditViewModel : BaseViewModel
    {
        public AccountEditViewModel()
        {
            UpdateUser = new Command(() => UserInputUpdate());
        }

        public ICommand UpdateUser { get; set; }
        async void UserInputUpdate()
        {
            var id = Int32.Parse(SecureStorage.GetAsync("Id").Result);
            User user = await RestService.GetUser(id);

            switch(Key)
            {
                case "First Name:":
                    user.Name = Value;
                    if (await SetUser(id, user))
                    {
                        SecureStorage.Remove("Name");
                        await SecureStorage.SetAsync("Name", Value);
                    }
                    break;
                case "Last Name:":
                    user.Surname = Value;
                    if (await SetUser(id, user))
                    {
                        SecureStorage.Remove("Surname");
                        await SecureStorage.SetAsync("Surname", Value);
                    }
                    break;
                case "Email:":
                    user.Email = Value;
                    if (await SetUser(id, user))
                    {
                        SecureStorage.Remove("Email");
                        await SecureStorage.SetAsync("Email", Value);
                    }
                    break;
                case "Birthday:":
                    user.DateOfBirth = DateTime.Parse(Value);
                    if (await SetUser(id, user))
                    {
                        SecureStorage.Remove("Birth");
                        await SecureStorage.SetAsync("Birth", Value);
                    }
                    break;
            }

            var appshell = Shell.Current as AppShell;
            await Task.Run(() => appshell.SetUser());

            //var account = new AccountViewModel();
            //account.UpdateData(); //does not work currently?
            
            await Shell.Current.GoToAsync($"//{nameof(AccountPage)}");
            //return to previous page of the stack
        }

        private async Task<bool> SetUser(int id, User user)
        {
            var response = await RestService.UpdateUser(id, user);
            return response;
        }

        private static string _value;
        public string Value
        {
            get { return _value; }
            set 
            { 
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        private static string key;
        public string Key
        {
            get { return key; }
            set
            {
                key = value;
                OnPropertyChanged("Key");
            }
        }
    }
}