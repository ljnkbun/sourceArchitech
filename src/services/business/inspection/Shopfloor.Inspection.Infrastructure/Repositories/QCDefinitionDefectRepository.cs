using AutoMapper;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class QCDefinitionDefectRepository : GenericRepositoryAsync<QCDefinitionDefect>, IQCDefinitionDefectRepository
    {
        private readonly DbSet<QCDefinitionDefect> _qcDefinitionDefect;
        public QCDefinitionDefectRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _qcDefinitionDefect = _dbContext.Set<QCDefinitionDefect>();
        }
        public async Task<List<QCDefinitionDefect>> GetByQCDefinitionIdAsync(int qcDefinitionId)
        {
            return await _qcDefinitionDefect.Where(x=>x.QCDefinitionId == qcDefinitionId).ToListAsync();
        }
       
    }
}
