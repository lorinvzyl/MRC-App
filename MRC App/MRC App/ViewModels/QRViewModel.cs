﻿using MRC_App.Models;
using MRC_App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MRC_App.ViewModels
{
    public class QRViewModel : BaseViewModel
    {
        public QRViewModel()
        {
        }

        public async Task AttendEvent(string result)
        {
            if (result != "Attend")
                return;

            var email = SecureStorage.GetAsync("Email").Result;

            UserEvent userEvent = new UserEvent
            {
                UserEmail = email,
                EventId = 1,
                isAttended = true
            };

            var response = await RestService.Attend(userEvent);
            if(response)
            {
                //return success
            }
            else
            {
                //error
            }
        }
    }
}
