using Midrand_Reformed_Church_App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Midrand_Reformed_Church_App.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}