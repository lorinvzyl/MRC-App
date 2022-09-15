using MRC_App.Models;
using MRC_App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MRC_App.ViewModels
{
    public class BlogDetailedViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Comment> comments;
        public ObservableRangeCollection<Comment> Comments
        {
            get { return comments; }
            set 
            { 
                comments = value;
                OnPropertyChanged();
            }
        }
        public BlogDetailedViewModel()
        {
            Comments = new ObservableRangeCollection<Comment>();
        }

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

        //GetComments
    }
}
