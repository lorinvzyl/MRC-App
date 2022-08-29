using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsDetailed : ContentPage
    {
        public EventsDetailed()
        {
            InitializeComponent();
        }
        public EventsDetailed(object item)
        {
            InitializeComponent();
        }
    }
}