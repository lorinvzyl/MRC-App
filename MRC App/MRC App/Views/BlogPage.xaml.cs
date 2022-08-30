using MRC_App.Models;
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
        public BlogPage()
        {
            InitializeComponent();

        }
        async void CollectionView_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {

            var detail = e.CurrentSelection.FirstOrDefault() as Blog;
            if (detail == null)
                return;
            var detailspage = new BlogDetailed();
            detailspage.BindingContext = detail;

            await Navigation.PushAsync(detailspage);
            ((CollectionView)sender).SelectedItem = null;

        }
    }
}