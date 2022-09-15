using MRC_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MRC_App.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPopUp : ContentPage
    {
        private ObservableRangeCollection<Navigation> nav;
        public ObservableRangeCollection<Navigation> Nav
        {
            get { return nav; }
            set 
            { 
                nav = value;
                OnPropertyChanged();
            }
        }
        public LocationPopUp()
        {
            InitializeComponent();

            Nav = new ObservableRangeCollection<Navigation>();
            BindingContext = this;
        }

        async void ItemSelected_CollectionView(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}