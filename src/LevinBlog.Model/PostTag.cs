﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LevinBlog.Model
{
    public class PostTag
    {
        public int PostTagId { get; set; }

        public int TagId { get; set; }

        public int PostId { get; set; }
    }
}