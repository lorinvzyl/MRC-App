using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string CommentText { get; set; }
        public int UserId { get; set; }

    }
}
