﻿using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class CompanyCurrencyRepository : MasterRepositoryAsync<CompanyCurrency>, ICompanyCurrencyRepository
    {
        public CompanyCurrencyRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
