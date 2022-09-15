using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using MRC_App.Models;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using MRC_App.Services;

namespace MRC_App.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Blog> Blog;
        private ObservableCollection<Video> Video;

        public ObservableRangeCollection<Blog> blog
        {
            get { return Blog; }
            set { Blog = value; }
        }

        public ObservableCollection<Video> video
        {
            get { return Video; }
            set { Video = value; }
        }


        public AboutViewModel()
        {
            blog = new ObservableRangeCollection<Blog>();
            video = new ObservableCollection<Video>();
            
            GetBlogs();
        }

        private async Task GetBlogs()
        {
            var blogs = await RestService.GetBlogsCount(3);
            Blog.AddRange(blogs);
        }

        public async Task Refresh()
        {
            IsBusy = true;

            Blog.Clear();
            Video.Clear();

            var blogs = await RestService.GetBlogs();
            //var video = await RestService.GetLastVideo();

            IsBusy = false;
        }
    }
}