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
        }

    }
}