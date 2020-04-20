namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IProfilePicturesService
    {
        Task<bool> AddPictureAsync(IFormFile file, string userId);

        Task AddPictureAsync(string imagePath, string userId);

        string GetAvatarByUserId(string userId);
    }
}
