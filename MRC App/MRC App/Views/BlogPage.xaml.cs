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
    public partial class BlogPage : ContentPage
    {
        BlogViewModel viewModel;
        public BlogPage()
        {
            InitializeComponent();
            /* Keeping this commented out for until after the presentation.
            BindingContext = viewModel;
            */
        }
    }
}