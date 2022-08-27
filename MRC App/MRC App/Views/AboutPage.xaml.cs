using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MRC_App.ViewModels;

namespace MRC_App.Views
{
    public partial class AboutPage : ContentPage
    {
        AboutViewModel viewModel;
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}