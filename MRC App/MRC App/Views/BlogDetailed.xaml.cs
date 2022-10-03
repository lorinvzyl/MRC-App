using MRC_App.Models;
using MRC_App.Services;
using MRC_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlogDetailed : ContentPage
    {
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
            BlogDetailedViewModel blogDetailedViewModel = new BlogDetailedViewModel();
            InitializeComponent();
            CommentEntry.Completed += (sender, e) => blogDetailedViewModel.AddBlogComment(CommentEntry.Text);
            //ReplyEntry.Completed += (sender, e) => EntryReplyCompleted(ReplyEntry.Text,sender, e);
            //not sure how to send current comment through for reply to be added.
        }
    }
}