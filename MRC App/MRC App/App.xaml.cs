using MRC_App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;
using System.Threading;

namespace MRC_App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            SetCultureToZA();

            MainPage = new AppShell();
        }

        private void SetCultureToZA()
        {
            CultureInfo culture = new CultureInfo("en-ZA");
            CultureInfo.DefaultThreadCurrentCulture = culture;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
