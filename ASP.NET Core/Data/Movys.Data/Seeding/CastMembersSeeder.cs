namespace Movys.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Movys.Data.Models;

    public class CastMembersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.CastMembers.Any())
            {
                CastMember castMember = new CastMember
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Hugh Jackman",
                    Description = "Jackman was born in Sydney, New South Wales, to Grace McNeil (Greenwood) and Christopher John Jackman, an accountant. He is the youngest of five children. His parents both English, moved to Australia shortly before his birth. He also has Greek (from a great-grandfather) and Scottish (from a grandmother) ancestry.Hugh Michael Jackman is an Australian actor, singer, multi-instrumentalist, dancer and producer. Jackman has won international recognition for his roles in major films, notably as superhero, period, and romance characters.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/83/HughJackmanByPaulCush2011.jpg",
                    BornInfo = "12 October 1968 (age 51)",
                    CountryBornIn = "USA",
                    Height = 182,
                };

                CastMember castMember1 = new CastMember
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Mark Wahlberg",
                    Description = "American actor Mark Wahlberg is one of a handful of respected entertainers who successfully made the transition from teen pop idol to acclaimed actor.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTU0MTQ4OTMyMV5BMl5BanBnXkFtZTcwMTQxOTY1NA@@._V1_SY1000_CR0,0,767,1000_AL_.jpg",
                    BornInfo = "June 5, 1971 (age 48)",
                    CountryBornIn = "USA",
                    Height = 178,
                };

                CastMember castMember2 = new CastMember
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Robert Downey Jr.",
                    Description = "Robert Downey Jr. has evolved into one of the most respected actors in Hollywood. With an amazing list of credits to his name, he has managed to stay new and fresh even after over four decades in the business.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BNzg1MTUyNDYxOF5BMl5BanBnXkFtZTgwNTQ4MTE2MjE@._V1_SY1000_CR0,0,664,1000_AL_.jpg",
                    BornInfo = "April 4, 1965 (age 54)",
                    CountryBornIn = "USA",
                    Height = 180,
                };

                CastMember castMember3 = new CastMember
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Sean Anders",
                    Description = "Sean Anders is an American film director and screenwriter.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTU5Njk2ODU2MF5BMl5BanBnXkFtZTcwMjM0NTgxOA@@._V1_SY1000_CR0,0,693,1000_AL_.jpg",
                    BornInfo = "April 4, 1962 (age 57)",
                    CountryBornIn = "USA",
                    Height = 188,
                };

                CastMember castMember4 = new CastMember
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Konstantin Statskiy",
                    Description = "Director of  Hotel Belgraud, Born with silver lajica.",
                    ImageUrl = "https://vokrug.tv/pic/person/4/7/5/b/475b91266b5159e7ffdc4f2aa90c7d97.jpeg",
                    BornInfo = "May 29, 1978 (age 54)",
                    CountryBornIn = "Russia",
                    Height = 185,
                };

                await dbContext.CastMembers.AddAsync(castMember);
                await dbContext.CastMembers.AddAsync(castMember1);
                await dbContext.CastMembers.AddAsync(castMember2);
                await dbContext.CastMembers.AddAsync(castMember3);
                await dbContext.CastMembers.AddAsync(castMember4);
            }
        }
    }
}
