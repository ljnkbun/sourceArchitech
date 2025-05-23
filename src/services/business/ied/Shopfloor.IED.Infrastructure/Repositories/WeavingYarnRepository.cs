﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class WeavingYarnRepository : GenericRepositoryAsync<WeavingYarn>, IWeavingYarnRepository
    {
        public WeavingYarnRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<List<WeavingYarn>> GetAllByWeavingIEDId(int weavingId) => await _dbContext.Set<WeavingYarn>().AsNoTracking()
            .Where(x => x.WeavingIEDId == weavingId).ToListAsync();
    }
}