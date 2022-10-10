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
using System.Windows.Input;
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

        private Comment selectedComment;
        public Comment SelectedComment
        {
            get { return selectedComment; }
            set
            {
                selectedComment = value;
                OnPropertyChanged(nameof(SelectedComment));
            }
        }

        public ICommand CommentCompleted;
        public ICommand ReplyCompleted;

        public BlogDetailedViewModel()
        {
            Comments = new ObservableRangeCollection<Comment>();
            CommentCompleted = new Command(AddBlogComment);
        }

        public async void AddBlogComment(object obj)
        {
            Comment comment = new Comment()
            {
                BlogId = Id,
                CommentText = CommentText,
                UserName = SecureStorage.GetAsync("Name").Result
            };

            await RestService.AddBlogComment(comment);
        }

        public async void AddCommentReply(object obj)
        {
            Comment comment = new Comment()
            {
                UserName = selectedComment.UserName,
                CommentText = selectedComment.CommentText,
                Id = selectedComment.Id,
                BlogId = selectedComment.BlogId
            };

            Reply reply = new Reply()
            {
                UserName = SecureStorage.GetAsync("Name").Result,
                CommentText = ReplyText,
                CommentId = comment.Id
            };

            ICollection<Reply> replies = new List<Reply>((IEnumerable<Reply>)reply);

            comment.Reply = replies;

            var response = await RestService.AddBlogReply(comment);

            if(response)
            {
                //do something
            }
        }

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

        public ICommand ItemSelectedCommand => new Command(async (item) => await SetComment(item));

        private async Task SetComment(object item)
        {
            if(item is Comment)
            {
                SelectedComment = (Comment)item;
            }
        }

        private async void GetComments(int blogId)
        {
            Comments.AddRange(await RestService.GetBlogComments(blogId));
        }

        private string replyText;
        public string ReplyText
        {
            get => replyText;
            set
            {
                replyText = value;
                OnPropertyChanged(nameof(ReplyText));
            }
        }

        private string commentText;
        public string CommentText
        {
            get { return commentText; }
            set
            {
                commentText = value;
                OnPropertyChanged(nameof(CommentText));
            }
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
