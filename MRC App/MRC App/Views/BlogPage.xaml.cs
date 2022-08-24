using MRC_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRC_App.Models;
using Xamarin.Forms;


namespace MRC_App.Views
{
    
    public partial class BlogPage : ContentPage
    {
        public BlogPage()
        {
            InitializeComponent();
            BindingContext = new BlogViewModel();
        }

        private async void myCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var detailsblog = e.CurrentSelection[0] as Blog;

            switch (detailsblog.ID)
            {
                case 1:
                    await Navigation.PushAsync(new BlogDetailed(detailsblog.Img));
                    break;
                case 2:
                    await Navigation.PushAsync(new BlogDetailed1());
                    break;
                case 3:
                    await Navigation.PushAsync(new BlogDetailed2());
                    break;
            }
        }


        
    }
}