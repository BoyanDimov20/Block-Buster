namespace Movys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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

        public IEnumerable<T> GetAll<T>()
        {
            return this.castMembersRepository.All().To<T>().ToList();
        }

        public int GetCount()
        {
            return this.castMembersRepository.All().Count();
        }
    }
}
