﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LevinBlog.Database.Entity
{
    [Table("PostTags")]
    public class PostTagEntity
    {
        [Key]
        public int PostTagId { get; set; }
        public int TagId { get; set; }

        public int PostId { get; set; }

        public TagEntity Tag { get; set; }

        public PostEntity Post { get; set; }
    }
}
