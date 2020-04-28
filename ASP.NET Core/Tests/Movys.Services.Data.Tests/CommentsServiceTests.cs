namespace Movys.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Movys.Data;
    using Movys.Data.Common.Repositories;
    using Movys.Data.Models;
    using Movys.Data.Repositories;
    using Movys.Services.Mapping;
    using Movys.Web.ViewModels.News;
    using Xunit;

    public class CommentsServiceTests
    {
        [Fact]
        public async Task CreateCommentCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<Comment>(new ApplicationDbContext(options.Options));

            var service = new CommentsService(repository);
            var userId = "45645645";
            var newsId = "1235876";

            await service.CreateCommentAsync("Ivan", userId, newsId);
            await service.CreateCommentAsync("Hello", userId, newsId);

            Assert.True(repository.All().All(x => x.NewsId == newsId && x.UserId == userId));
        }
    }
}
