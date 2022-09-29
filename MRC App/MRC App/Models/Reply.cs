using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Models
{
    public class Reply
    {
        public int? Id { get; set; }
        public string CommentText { get; set; }
        public int? CommentId { get; set; }
        public string UserName { get; set; }
    }
}
