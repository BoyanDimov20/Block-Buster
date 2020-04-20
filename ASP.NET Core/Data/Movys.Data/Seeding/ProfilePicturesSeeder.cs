namespace Movys.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Movys.Data.Models;
    using Movys.Data.Repositories;
    using Movys.Services.Data;

    public class ProfilePicturesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.ProfilePictures.Any())
            {
                IProfilePicturesService profilePicturesService = new ProfilePicturesService(new EfRepository<ProfilePicture>(dbContext));
                var userId = dbContext.Users.Select(x => x.Id).First();

                await profilePicturesService.AddPictureAsync("wwwroot/images/DefaultPhoto.png", userId);
            }
        }
    }
}
