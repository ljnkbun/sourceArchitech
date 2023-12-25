using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class ConcentrateRepository : MasterRepositoryAsync<Concentrate>, IConcentrateRepository
    {
        public ConcentrateRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
