using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class PORDetailRepository : GenericRepositoryAsync<PORDetail>, IPORDetailRepository
    {
        private readonly DbSet<PORDetail> _pORDetail;
        public PORDetailRepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _pORDetail = dbContext.Set<PORDetail>();
        }

        public override async Task<PORDetail> GetByIdAsync(int id)
        {
            return await _pORDetail.Include(x=>x.ToMergeSplitPorDetails).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
