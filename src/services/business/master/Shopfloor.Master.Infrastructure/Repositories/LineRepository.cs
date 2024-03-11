using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class LineRepository : MasterRepositoryAsync<Line>, ILineRepository
    {
        private readonly DbSet<Line> _lines;
        public LineRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _lines = dbContext.Set<Line>();
        }

        public async Task<IReadOnlyList<Line>> GetLineByIdsAsync(List<int> ids)
        {
            return await _lines.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
