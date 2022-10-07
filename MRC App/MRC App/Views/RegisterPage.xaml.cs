using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterBtnClicked(object sender, EventArgs e)
        {
             await DisplayAlert("Update", "User has been registered successfully.", "Ok");
        }
    }
}