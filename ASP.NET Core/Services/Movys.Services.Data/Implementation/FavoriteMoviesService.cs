namespace Movys.Services.Data
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

    public class FavoriteMoviesService : IFavoriteMoviesService
    {
        private readonly IRepository<MoviesUser> repository;

        public FavoriteMoviesService(IRepository<MoviesUser> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllByUserId<T>(string userId)
        {
            return await this.repository.All().Where(x => x.UserId == userId).To<T>().ToListAsync();
        }
    }
}
