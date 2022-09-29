using MRC_App.Models;
using MRC_App.ViewModels;
using Newtonsoft.Json;
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
        public BlogPage()
        {
            InitializeComponent();

        }
        async void CollectionView_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.CurrentSelection.FirstOrDefault() is Blog detail))
                return;

            var json = JsonConvert.SerializeObject(detail);
            await Shell.Current.GoToAsync($"{nameof(BlogDetailed)}?Param={json}");
            ((CollectionView)sender).SelectedItem = null;

        }
    }
}