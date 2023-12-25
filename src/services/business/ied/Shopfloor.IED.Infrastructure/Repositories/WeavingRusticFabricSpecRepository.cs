﻿using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class WeavingRusticFabricSpecRepository : GenericRepositoryAsync<WeavingRusticFabricSpec>, IWeavingRusticFabricSpecRepository
    {
        public WeavingRusticFabricSpecRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
