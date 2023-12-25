using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class SpinningMethodRepository : MasterRepositoryAsync<SpinningMethod>, ISpinningMethodRepository
    {
        public SpinningMethodRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
