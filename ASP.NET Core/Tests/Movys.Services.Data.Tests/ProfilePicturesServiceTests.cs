namespace Movys.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Movys.Data;
    using Movys.Data.Models;
    using Movys.Data.Repositories;
    using Xunit;

    public class ProfilePicturesServiceTests
    {
        [Fact]
        public async Task AddProfilePictureByUrlOverwriteCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfRepository<ProfilePicture>(new ApplicationDbContext(options.Options));

            var service = new ProfilePicturesService(repository);
            var url1 = "Resources\\test1.jpeg";
            var userId = "123";
            var url2 = "Resources\\test2.jpg";

            await service.AddPictureAsync(url1, userId);
            var firstPictureId = repository.All().First().Id;

            await service.AddPictureAsync(url2, userId);

            Assert.Single(repository.All().Where(x => x.UserId == userId));
            Assert.NotEqual(firstPictureId, repository.All().First().Id);
        }

        [Fact]
        public async Task AddProfilePictureByUrlCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfRepository<ProfilePicture>(new ApplicationDbContext(options.Options));

            var service = new ProfilePicturesService(repository);
            var url1 = "Resources\\test1.jpeg";

            var url2 = "Resources\\test2.jpg";

            await service.AddPictureAsync(url1, "123");
            await service.AddPictureAsync(url2, "12345");

            Assert.Equal(2, repository.All().Count());
        }
    }
}
