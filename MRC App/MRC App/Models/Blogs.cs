﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Models
{
    public class Blog
    {
        public int ID { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }

    }
}
