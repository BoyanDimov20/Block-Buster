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

    public class CelebsService : ICelebsService
    {
        private readonly IDeletableEntityRepository<CastMember> castMembersRepository;

        public CelebsService(IDeletableEntityRepository<CastMember> castMembersRepository)
        {
            this.castMembersRepository = castMembersRepository;
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            return await this.castMembersRepository.All().To<T>().ToListAsync();
        }

        public int GetCount()
        {
            return this.castMembersRepository.All().Count();
        }
    }
}
