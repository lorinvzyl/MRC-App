using MRC_App.Models;
using MRC_App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRC_App.ViewModels
{
    public class DonateViewModel : BaseViewModel
    {
        public DonateViewModel()
        {
        }

        public async Task<bool> Donate(int amount, string message, string email)
        {
            //Add third party payment here, if successful, continue with adding with database
            if (message == null || email == null)
                return false;

            Donation donation = new Donation()
            {
                Amount = amount,
                Message = message,
                UserEmail = email
            };

            var result = await RestService.Donate(donation);
            return result;
        }
    }
}
