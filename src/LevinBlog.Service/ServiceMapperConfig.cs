﻿using LevinBlog.Database.Entity.Models;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LevinBlog.Database.Entity;
using LevinBlog.Model;

namespace Pioneer.Blog.Service
{
    public static class ServiceMapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserEntity>().ReverseMap();
                cfg.CreateMap<Article, ArticleEntity>().ReverseMap();
                cfg.CreateMap<Category, CategoryEntity>().ReverseMap();
                cfg.CreateMap<Contact, ContactEntity>().ReverseMap();
                cfg.CreateMap<Excerpt, ExcerptEntity>().ReverseMap();
                cfg.CreateMap<PostTag, PostTagEntity>().ReverseMap();
                cfg.CreateMap<Tag, TagEntity>().ReverseMap();
                cfg.CreateMap<PostEntity, Post>()
                 .ForMember(dto => dto.Tags, opt => opt.MapFrom(x => x.PostTags.Select(t => t.Tag))).ReverseMap();
                cfg.CreateMap<PostTagEntity, Tag>().ReverseMap();
                cfg.CreateMap<List<PostEntity>, List<Post>>().ReverseMap();
            });
        }
    }
}
