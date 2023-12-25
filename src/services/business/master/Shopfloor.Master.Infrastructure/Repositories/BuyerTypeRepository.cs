﻿using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class BuyerTypeRepository : MasterRepositoryAsync<BuyerType>, IBuyerTypeRepository
    {
        public BuyerTypeRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

    }
}
