using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string CommentText { get; set; }
        public string User { get; set; }

    }
}
