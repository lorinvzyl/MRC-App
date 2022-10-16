using MRC_App.Models;
using MRC_App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MRC_App.ViewModels
{
    public class DonateViewModel : BaseViewModel
    {
        public DonateViewModel()
        {
        }

        public async Task<bool> Donate()
        {
            //Add third party payment here, if successful, continue with adding with database

            Donation donation = new Donation()
            {
                Amount = Amount,
                Message = Message,
                UserEmail = SecureStorage.GetAsync("Email").Result
            };

            var result = await RestService.Donate(donation);
            return result;
        }

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            set
            {
                if(value > 0)
                {
                    amount = value;
                    OnPropertyChanged(nameof(Amount));
                }
            }
        }

        private bool enabled;
        public bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                OnPropertyChanged(nameof(Enabled));
            }
        }

        private bool amountValid;
        public bool AmountValid
        {
            get { return amountValid; }
            set
            {
                amountValid = value;
                OnPropertyChanged(nameof(AmountValid));
            }
        }

        public ICommand EnableCommand => new Command(IsEnabledMethod);

        private async void IsEnabledMethod(object obj)
        {
            if (AmountValid == true)
                Enabled = true;
            else
                Enabled = false;
        }
    }
}
