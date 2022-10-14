using MRC_App.Models;
using MRC_App.Services;
using MRC_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlogDetailed : ContentPage
    {
        BlogDetailedViewModel bdvm = new BlogDetailedViewModel();

        public event EventHandler Completed;
        private static int blogId;
        public int BlogId
        {
            get { return blogId; }
            set
            {
                blogId = value;
                OnPropertyChanged(nameof(BlogId));
            }
        }
        public BlogDetailed()
        {
            InitializeComponent();
            _ = InitialiseEntry();
        }

        public async Task InitialiseEntry()
        {
            BlogDetailedViewModel blogDetailedViewModel = new BlogDetailedViewModel();
        }

        int i = 0;
        
    }
}