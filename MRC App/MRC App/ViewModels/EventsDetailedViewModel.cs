using MRC_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MRC_App.ViewModels
{
    [QueryProperty(nameof(Param), nameof(Param))]
    public class EventsDetailedViewModel : BaseViewModel
    {
        string param = "";
        public string Param
        {
            get => param;
            set
            {
                param = Uri.UnescapeDataString(value ?? string.Empty);
                OnPropertyChanged();
                PerformOperation(param);
            }
        }

        private string eventName { get; set; }
        public string EventName
        {
            get { return eventName; }
            set
            {
                eventName = value;
                OnPropertyChanged("EventName");
            }
        }
        private string eventDescription { get; set; }
        public string EventDescription
        {
            get { return eventDescription; }
            set
            {
                eventDescription = value;
                OnPropertyChanged("EventDescription");
            }
        }


        private void PerformOperation(string paramStr)
        {
            var param = JsonConvert.DeserializeObject<Events>(paramStr);
            EventName = param.Name;
            EventDescription = param.Description;
        }
    }
}
