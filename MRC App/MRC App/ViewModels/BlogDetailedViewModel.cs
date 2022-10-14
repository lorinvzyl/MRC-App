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
using Xamarin.CommunityToolkit.UI.Views;
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

        private Comment selectedComment = null;
        public Comment SelectedComment
        {
            get { return selectedComment; }
            set
            {
                if(selectedComment != value)
                {
                    selectedComment = value;
                    OnPropertyChanged(nameof(SelectedComment));
                }
            }
        }

        public ICommand CommentCompleted => new Command(AddBlogComment);
        public ICommand ReplyCompleted => new Command(AddCommentReply);

        public BlogDetailedViewModel()
        {
            Comments = new ObservableRangeCollection<Comment>();
        }

        public async void AddBlogComment(object obj)
        {
            Comment comment = new Comment()
            {
                BlogId = Id,
                CommentText = CommentText,
                UserEmail = SecureStorage.GetAsync("Email").Result
            };

            await RestService.AddBlogComment(comment);
        }

        public async void AddCommentReply(object obj)
        {
            Reply reply = new Reply()
            {
                UserName = SecureStorage.GetAsync("Name").Result,
                CommentText = SelectedComment.ReplyText,
                CommentId = selectedComment.Id
            };

            var response = await RestService.AddBlogReply(reply);

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

        public ICommand ReadMoreLess => new Command(ReadMoreLessMethod);

        private void ReadMoreLessMethod(object obj)
        {
            if (TextLines == 20)
                TextLines = 300;
            else
                TextLines = 20;
        }

        private int textLines;
        public int TextLines
        {
            get { return textLines; }
            set
            {
                SetProperty(ref textLines, value);
            }
        }

        private string contentLength;
        public string ContentLength
        {
            get { return contentLength; }
            set
            {
                SetProperty(ref contentLength, value);
            }
        }

        public ICommand ItemSelectedCommand => new Command(item => Expander_Tapped(item));

        private async void GetComments(int blogId)
        {
            var blogs = await RestService.GetBlogComments(blogId);
            if(blogs != null)
                Comments.AddRange(blogs);
        }

        int i = 0;

        public void Expander_Tapped(object item)
        {
            if (item is Comment comment)
            {
                var list = Comments;
                foreach (var x in list)
                {
                    if (x.UserName == comment.UserName && x.CommentText == comment.CommentText)
                    {
                        x.Expanded = true;
                        SelectedComment = x;
                        i++;

                        if (i >= 1)
                        {
                            var commentlist = new List<Comment>(Comments);

                            foreach (var item1 in commentlist)
                            {
                                if (item1.CommentText != comment.CommentText && item1.UserName != comment.UserName)
                                {
                                    item1.Expanded = false;
                                }
                            }
                            i = 0;
                        }
                    }
                }
                Comments = list;
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
