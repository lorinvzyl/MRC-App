using Xamarin.Forms;
using MRC_App.Models;
using System.Linq;
using Newtonsoft.Json;

namespace MRC_App.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void CollectionView_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.CurrentSelection.FirstOrDefault() is Blog blog))
                return;

            var json = JsonConvert.SerializeObject(blog);
            await Shell.Current.GoToAsync($"{nameof(BlogDetailed)}?Param={json}");
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}