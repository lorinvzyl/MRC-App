using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MRC_App.Models;
using MRC_App.Services;

namespace MRC_App.ViewModels
{
    public class BlogViewModel : BaseViewModel
    {
        private ObservableCollection<BlogComment> Blog;
        public ObservableCollection<BlogComment> blog
        {
            get { return Blog; }
            set { Blog = value; }
        }

        public BlogViewModel()
        {
            blog = new ObservableCollection<BlogComment>();
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
            if (blog == null || commentText == null || user == null)
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
    }
}
