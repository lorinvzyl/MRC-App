using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MRC_App.Models;
using MRC_App.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MRC_App.ViewModels
{
    public class BlogViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Blog> blogs;
        public ObservableRangeCollection<Blog> Blogs
        {
            get { return blogs; }
            set { blogs = value; }
        }

        public BlogViewModel()
        {
            Blogs = new ObservableRangeCollection<Blog>();

            AddBlogs();
        }

        async Task AddBlogs()
        {
            var result = await RestService.GetBlogs();
            Blogs.AddRange(result);
        }

        async Task Refresh()
        {
            IsBusy = true;

            Blogs.Clear();

            var result = await RestService.GetBlogs();
            Blogs.AddRange(result);

            IsBusy = false;
        }
    }
}
