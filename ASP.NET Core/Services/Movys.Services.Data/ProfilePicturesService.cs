namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Movys.Data.Common.Repositories;
    using Movys.Data.Models;

    public class ProfilePicturesService : IProfilePicturesService
    {
        private readonly IRepository<ProfilePicture> repository;

        public ProfilePicturesService(IRepository<ProfilePicture> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddPictureAsync(IFormFile file, string userId)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    var photo = new ProfilePicture()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UploadDate = DateTime.UtcNow,
                        Content = memoryStream.ToArray(),
                        Size = memoryStream.Length,
                        UserId = userId,
                    };

                    if (this.repository.All().Any(x => x.UserId == userId))
                    {
                        this.repository.Delete(this.repository.All().First(x => x.UserId == userId));
                    }

                    await this.repository.AddAsync(photo);
                    await this.repository.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

        public async Task AddPictureAsync(string imagePath, string userId)
        {
            byte[] imageByteArray = null;
            using FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            using BinaryReader reader = new BinaryReader(fileStream);
            imageByteArray = new byte[reader.BaseStream.Length];
            for (int i = 0; i < reader.BaseStream.Length; i++)
            {
                imageByteArray[i] = reader.ReadByte();
            }

            var photo = new ProfilePicture()
            {
                Id = Guid.NewGuid().ToString(),
                UploadDate = DateTime.UtcNow,
                Content = imageByteArray,
                Size = imageByteArray.Length,
                UserId = userId,
            };

            if (this.repository.All().Any(x => x.UserId == userId))
            {
                this.repository.Delete(this.repository.All().First(x => x.UserId == userId));
            }

            await this.repository.AddAsync(photo);
            await this.repository.SaveChangesAsync();
        }

        public string GetAvatarByUserId(string userId)
        {
            byte[] bytesArr = this.repository.All().FirstOrDefault(x => x.UserId == userId).Content;
            var result = Convert.ToBase64String(bytesArr);
            return result;
        }
    }
}
