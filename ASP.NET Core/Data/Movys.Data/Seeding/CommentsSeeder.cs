namespace Movys.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Movys.Data.Models;

    public class CommentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Comments.Any())
            {
                var userId = dbContext.Users.Select(x => x.Id).First();
                var newsIds = dbContext.News.Select(x => x.Id).ToList();

                foreach (var newsId in newsIds)
                {
                    var comment = new Comment
                    {
                        Id = Guid.NewGuid().ToString(),
                        Content = "Their world is about to get a lot bigger and a whole lot louder. A member of hard-rock royalty, Queen Barb, aided by her father King Thrash, wants to destroy all other kinds of music to let rock reign supreme. With the fate of the world at stake, Poppy and Branch, along with their friends, set out to visit all the other lands to unify the Trolls in harmony against Barb, who's looking to upstage them all.",
                        UserId = userId,
                        NewsId = newsId,
                    };
                    await dbContext.Comments.AddAsync(comment);
                }
            }
        }
    }
}
