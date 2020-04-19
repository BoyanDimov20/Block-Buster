namespace Movys.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Movys.Data.Models;

    public class NewsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.News.Any())
            {
                Random rng = new Random();
                var news1 = new News
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "New Mulan Movie",
                    ImageUrl = "https://resizing.flixster.com/28Q_OPlGaFk3_F9-Ir7TETGgZDA=/fit-in/200x296.2962962962963/v1.bTsxMzI2MzQyMjtqOzE4NDIzOzEyMDA7NjQ4Ozk2MA",
                    Content = "When the Emperor of China issues a decree that one man per family must serve in the Imperial Army to defend the country from Northern invaders, Hua Mulan, the eldest daughter of an honored warrior, steps in to take the place of her ailing father. Masquerading as a man, Hua Jun, she is tested every step of the way and must harness her inner-strength and embrace her true potential. It is an epic journey that will transform her into an honored warrior and earn her the respect of a grateful nation...and a proud father.",
                    Category = (NewsCategory)rng.Next(1, 5),
                };

                var news2 = new News
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Trolls World Tour is coming",
                    ImageUrl = "https://www.dreamworks.com/storage/cms-uploads/trolls-april-10-poster-gallery.jpg",
                    Content = "Poppy and Branch discover that they are but one of six different Troll tribes scattered over six different lands devoted to six different kinds of music: Funk, Country, Techno, Classical, Pop and Rock. Their world is about to get a lot bigger and a whole lot louder. A member of hard-rock royalty, Queen Barb, aided by her father King Thrash, wants to destroy all other kinds of music to let rock reign supreme. With the fate of the world at stake, Poppy and Branch, along with their friends, set out to visit all the other lands to unify the Trolls in harmony against Barb, who's looking to upstage them all.",
                    Category = (NewsCategory)rng.Next(1, 5),
                };

                var news3 = new News
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Trolls World Tour is coming",
                    ImageUrl = "https://www.dreamworks.com/storage/cms-uploads/trolls-april-10-poster-gallery.jpg",
                    Content = "Poppy and Branch discover that they are but one of six different Troll tribes scattered over six different lands devoted to six different kinds of music: Funk, Country, Techno, Classical, Pop and Rock. Their world is about to get a lot bigger and a whole lot louder. A member of hard-rock royalty, Queen Barb, aided by her father King Thrash, wants to destroy all other kinds of music to let rock reign supreme. With the fate of the world at stake, Poppy and Branch, along with their friends, set out to visit all the other lands to unify the Trolls in harmony against Barb, who's looking to upstage them all.",
                    Category = (NewsCategory)rng.Next(1, 5),
                };

                var news4 = new News
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Trolls World Tour is coming",
                    ImageUrl = "https://www.dreamworks.com/storage/cms-uploads/trolls-april-10-poster-gallery.jpg",
                    Content = "Poppy and Branch discover that they are but one of six different Troll tribes scattered over six different lands devoted to six different kinds of music: Funk, Country, Techno, Classical, Pop and Rock. Their world is about to get a lot bigger and a whole lot louder. A member of hard-rock royalty, Queen Barb, aided by her father King Thrash, wants to destroy all other kinds of music to let rock reign supreme. With the fate of the world at stake, Poppy and Branch, along with their friends, set out to visit all the other lands to unify the Trolls in harmony against Barb, who's looking to upstage them all.",
                    Category = (NewsCategory)rng.Next(1, 5),
                };

                var news5 = new News
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Trolls World Tour is coming",
                    ImageUrl = "https://www.dreamworks.com/storage/cms-uploads/trolls-april-10-poster-gallery.jpg",
                    Content = "Poppy and Branch discover that they are but one of six different Troll tribes scattered over six different lands devoted to six different kinds of music: Funk, Country, Techno, Classical, Pop and Rock. Their world is about to get a lot bigger and a whole lot louder. A member of hard-rock royalty, Queen Barb, aided by her father King Thrash, wants to destroy all other kinds of music to let rock reign supreme. With the fate of the world at stake, Poppy and Branch, along with their friends, set out to visit all the other lands to unify the Trolls in harmony against Barb, who's looking to upstage them all.",
                    Category = (NewsCategory)rng.Next(1, 5),
                };

                var news6 = new News
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Trolls World Tour is coming",
                    ImageUrl = "https://www.dreamworks.com/storage/cms-uploads/trolls-april-10-poster-gallery.jpg",
                    Content = "When the Emperor of China issues a decree that one man per family must serve in the Imperial Army to defend the country from Northern invaders, Hua Mulan, the eldest daughter of an honored warrior, steps in to take the place of her ailing father. Masquerading as a man, Hua Jun, she is tested every step of the way and must harness her inner-strength and embrace her true potential. It is an epic journey that will transform her into an honored warrior and earn her the respect of a grateful nation...and a proud father.",
                    Category = (NewsCategory)rng.Next(1, 5),
                };

                await dbContext.AddAsync(news1);
                await dbContext.AddAsync(news2);
                await dbContext.AddAsync(news3);
                await dbContext.AddAsync(news4);
                await dbContext.AddAsync(news5);
                await dbContext.AddAsync(news6);

            }
        }
    }
}
