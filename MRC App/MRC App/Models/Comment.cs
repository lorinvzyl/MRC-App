using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Models
{
    public class Comment
    {
        public Comment()
        {
            Replies = new HashSet<Reply>();
        }
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string UserName { get; set; }
        public int BlogId { get; set; }
        public ICollection<Reply> Replies { get; set; }
    }
}
