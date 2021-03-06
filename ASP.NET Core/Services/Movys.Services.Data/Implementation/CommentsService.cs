﻿namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Movys.Data.Common.Repositories;
    using Movys.Data.Models;
    using Movys.Services.Mapping;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> entityRepository;

        public CommentsService(IDeletableEntityRepository<Comment> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public async Task CreateCommentAsync(string content, string userId, string newsId)
        {
            Comment comment = new Comment
            {
                Id = Guid.NewGuid().ToString(),
                Content = content,
                UserId = userId,
                NewsId = newsId,
            };
            await this.entityRepository.AddAsync(comment);
            await this.entityRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllByNewsId<T>(string id)
        {
            return await this.entityRepository.All().Where(x => x.NewsId == id).To<T>().ToListAsync();
        }

        public int GetCount()
        {
            return this.entityRepository.All().Count();
        }
    }
}
