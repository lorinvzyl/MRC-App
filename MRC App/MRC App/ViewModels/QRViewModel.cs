using MRC_App.Models;
using MRC_App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MRC_App.ViewModels
{
    public class QRViewModel : BaseViewModel
    {
        public QRViewModel()
        {
        }

        public async Task AttendEvent(string result)
        {
            if (!result.StartsWith("https://reformedchurchmidrandapi.azurewebsites.net/api/UserEvents/Attend/"))
                return;

            int id = 0;
            var response1 = Int32.TryParse(result.Substring(result.Length - 1), out id);
            var response = false;

            if(response1)
            {
                var email = SecureStorage.GetAsync("Email").Result;

                UserEvent userEvent = new UserEvent
                {
                    UserEmail = email,
                    EventId = id,
                    isAttended = true
                };

                response = await RestService.Attend(userEvent);
            }
            
            if (!response)
            {
                Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Error", "Something went wrong", "Ok"));
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Success", "Attended", "Ok"));
            }
        }
    }
}
