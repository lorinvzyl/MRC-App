using MRC_App.ViewModels;
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
    public partial class AccountEdit : ContentPage
    {
        public AccountEdit()
        {
            InitializeComponent();
        }

        public AccountEdit(string key, string value)
        {
            InitializeComponent();

            AccountEditViewModel _ = new AccountEditViewModel
            {
                Key = key,
                Value = value
            };
        }
    }
}