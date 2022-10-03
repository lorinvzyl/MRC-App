using MRC_App.Controls;
using MRC_App.Models;
using MRC_App.Services;
using MRC_App.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MRC_App.ViewModels
{
    [QueryProperty(nameof(Param), nameof(Param))]
    public class BlogDetailedViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Comment> comments;
        public ObservableRangeCollection<Comment> Comments
        {
            get { return comments; }
            set 
            { 
                comments = value;
                OnPropertyChanged(nameof(Comments));
            }
        }

        public BlogDetailedViewModel()
        {
            Comments = new ObservableRangeCollection<Comment>();
        }

        public async Task<bool> AddBlogComment(string commentText)
        {
            if (commentText == null)
                return false;

            Comment comment = new Comment()
            {
                BlogId = Id,
                CommentText = commentText,
                UserName = SecureStorage.GetAsync("Name").Result
            };

            var result = await RestService.AddBlogComment(comment);
            return result;
        }

        //AddCommentReply needs 

        string param = "";
        public string Param
        {
            get => param;
            set
            {
                param = Uri.UnescapeDataString(value ?? string.Empty);
                OnPropertyChanged();
                PerformOperation(param);
            }
        }

        private async void PerformOperation(string paramStr)
        {
            var param = JsonConvert.DeserializeObject<Blog>(paramStr);
            Id = param.Id;
            BlogTitle = param.BlogTitle;
            Content = param.Content;
            Description = param.Description;
            Author = param.Author;
            ImagePath = param.ImagePath;

            BlogDetailed blogDetailed = new BlogDetailed();
            blogDetailed.BlogId = Id;
            
            GetComments(param.Id);
        }

        public bool Expanded { get; set; }

        private async void GetComments(int blogId)
        {
            Comments.AddRange(await RestService.GetBlogComments(blogId));
        }

        //Comments
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string blogTitle;
        public string BlogTitle
        {
            get { return blogTitle; }
            set
            {
                blogTitle = value;
                OnPropertyChanged(nameof(BlogTitle));
            }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
    }
}
