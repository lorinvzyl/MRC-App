using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Models
{
    public class BlogComment
    {
        public BlogComment()
        {
            Replies = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string User { get; set; }
        public int BlogId { get; set; }
        public ICollection<Comment> Replies { get; set; }
    }
}
