using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MRC_App.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string BlogTitle { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }

    }
}
