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
        private ObservableRangeCollection<Comment> blogComment;
        public ObservableRangeCollection<Comment> BlogComment
        {
            get { return blogComment; }
            set { blogComment = value; }
        }

        private ObservableRangeCollection<Blog> blogs;
        public ObservableRangeCollection<Blog> Blogs
        {
            get { return blogs; }
            set { blogs = value; }
        }

        public BlogViewModel()
        {
            BlogComment = new ObservableRangeCollection<Comment>();
            Blogs = new ObservableRangeCollection<Blog>();

            AddBlogs();
        }

        /*
        public async Task GetComments(int blogId)
        {
            if (blogId == null)
                return;

        }
        */
        public async Task<bool> AddBlogComment(int blogId, string commentText, int parentId, string user)
        {
            if (commentText == null || user == null)
                return false;

            Comment comment = new Comment()
            {
                BlogId = blogId,
                CommentText = commentText,
                ParentId = parentId,
                User = user
            };

            var result = await RestService.AddBlogComment(comment);
            return result;
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
