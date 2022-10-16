using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MRC_App.Models;
using MRC_App.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace MRC_App.ViewModels
{
    public class BlogViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Blog> blogs;
        public ObservableRangeCollection<Blog> Blogs
        {
            get { return blogs; }
            set 
            {
                blogs = value;
                OnPropertyChanged(nameof(Blogs));
            }
        }

        public ICommand RefreshCommand;

        public BlogViewModel()
        {
            Blogs = new ObservableRangeCollection<Blog>();
            RefreshCommand = new Command(Refresh);

            AddBlogs();
        }

        public BlogViewModel(bool isTest)
        {
            Blogs = new ObservableRangeCollection<Blog>();
        }

        async Task AddBlogs()
        {
            var result = await RestService.GetBlogs();
            Blogs.AddRange(result);
        }

        async void Refresh(object obj)
        {
            IsBusy = true;

            Blogs.Clear();

            var result = await RestService.GetBlogs();
            Blogs.AddRange(result);

            IsBusy = false;
        }
    }
}
