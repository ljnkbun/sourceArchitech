using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;
using Shopfloor.Production.Infrastructure.Contexts;

namespace Shopfloor.Production.Infrastructure.Repositories
{
    public class FPPOOutputRepository : GenericRepositoryAsync<FPPOOutput>, IFPPOOutputRepository
    {
        private readonly DbSet<FPPOOutput> _fPPOOutputs;
        public FPPOOutputRepository(ProductionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _fPPOOutputs = dbContext.Set<FPPOOutput>();
        }

        public async Task<FPPOOutput> GetDeepByIdAsync(int id)
        {
            return await _fPPOOutputs.Include(x => x.FPPODetails).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
