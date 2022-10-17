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

            AccountEditViewModel viewmodel = new AccountEditViewModel
            {
                Key = key,
                Value = value
            };

            BindingContext = viewmodel;

            if (key == "Email:")
            {
                Xamarin.CommunityToolkit.Behaviors.EmailValidationBehavior emailValidationBehavior = new Xamarin.CommunityToolkit.Behaviors.EmailValidationBehavior();
                emailValidationBehavior.MinimumLength = 2;
                emailValidationBehavior.DecorationFlags = Xamarin.CommunityToolkit.Behaviors.TextDecorationFlags.Trim;
                emailValidationBehavior.Flags = Xamarin.CommunityToolkit.Behaviors.ValidationFlags.ValidateOnValueChanging;
                emailValidationBehavior.IsValid = viewmodel.IsValid;

                ValueEntry.Behaviors.Add(emailValidationBehavior);
            }

            if(key == "Birthday:")
            {
                Xamarin.CommunityToolkit.Behaviors.TextValidationBehavior textValidationBehavior = new Xamarin.CommunityToolkit.Behaviors.TextValidationBehavior();
                textValidationBehavior.Flags = Xamarin.CommunityToolkit.Behaviors.ValidationFlags.ValidateOnValueChanging;
                textValidationBehavior.IsValid = viewmodel.IsValid;
                textValidationBehavior.RegexPattern = @"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$";

                ValueEntry.Behaviors.Add(textValidationBehavior);
            }
        }
    }
}