﻿using System;
using System.Collections.Generic;
using System.Linq;
using LevinBlog.Database;
using LevinBlog.Database.Entity;
using LevinBlog.Model;

namespace LevinBlog.Repository
{
    public interface ITagRepository
    {
        IEnumerable<TagEntity> GetAll();
        IEnumerable<TagEntity> GetAllPaged(int count, int page);
        TagEntity GetById(int id);
        TagEntity Add(TagEntity tagEntity);
        void Update(Tag tag);
        void Remove(int id);
    }

    public class TagRepository : ITagRepository
    {
        private readonly BlogContext _blogContext;

        public TagRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        /// <summary>
        /// Get all Tags
        /// </summary>
        /// <returns>Tag Collection</returns>
        public IEnumerable<TagEntity> GetAll()
        {
            return _blogContext
                      .Tags
                      .ToList();
        }

        /// <summary>
        /// Get Tag By Id
        /// </summary>
        /// <param name="id">Tag Id</param>
        /// <returns>Tag Entity</returns>
        public TagEntity GetById(int id)
        {
            return _blogContext
                    .Tags
                    .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Create Tag
        /// </summary>
        /// <param name="tagEntity">Tag Entity to save</param>
        /// <returns>Tag Entity with Id</returns>
        public TagEntity Add(TagEntity tagEntity)
        {
            _blogContext
                .Tags
                .Add(tagEntity);
            _blogContext.SaveChanges();

            return tagEntity;
        }

        /// <summary>
        /// Update Entity based on Model
        /// </summary>
        /// <param name="tag">Tag Object</param>
        public void Update(Tag tag)
        {
            var entity = _blogContext
                .Tags
                .FirstOrDefault(x => x.Id == tag.Id);

            entity.Url = tag.Url;
            entity.Name = tag.Name;
            entity.IsActive = tag.IsActive;
            _blogContext.SaveChanges();
        }

        /// <summary>
        /// Remove Tag record based on Id
        /// </summary>
        /// <param name="id">Tag Id</param>
        public void Remove(int id)
        {
            var entity = _blogContext
                .Tags
                .FirstOrDefault(x => x.Id == id);
            entity.IsActive = false;
            _blogContext.SaveChanges();
        }

        /// <summary>
        /// Get a collection of tags by skipping x and taking y
        /// </summary>
        /// <param name="count">The total number of tags you want to Take</param>
        /// <param name="page">The denomination of tags you want to skip. (page - 1) * count </param>
        /// <returns>Collections of Tags</returns>
        public IEnumerable<TagEntity> GetAllPaged(int count, int page)
        {
            return _blogContext
                    .Tags
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();
        }
    }
}