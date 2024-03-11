using AutoMapper;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class QCDefectRepository : MasterRepositoryAsync<QCDefect>, IQCDefectRepository
    {
        private readonly DbSet<QCDefect> _qcDefects;
        public QCDefectRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _qcDefects = _dbContext.Set<QCDefect>();
        }
        public async Task<ICollection<QCDefect>> GetByIdsAsync(int[] ids)
        {
            return await _qcDefects.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
