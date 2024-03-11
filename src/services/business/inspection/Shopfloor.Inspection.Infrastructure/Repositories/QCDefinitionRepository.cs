using AutoMapper;
using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class QCDefinitionRepository : MasterRepositoryAsync<QCDefinition>, IQCDefinitionRepository
    {
        private readonly DbSet<QCDefinition> _qcDefinitions;
        private readonly DbSet<QCDefinitionDefect> _qcQCDefinitionDefects;
        public QCDefinitionRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _qcDefinitions = _dbContext.Set<QCDefinition>();
            _qcQCDefinitionDefects = _dbContext.Set<QCDefinitionDefect>();
        }
        public async Task<QCDefinition> GetQCDefinitionByCode(string code)
        {
            return await _qcDefinitions.Include(x => x.AQLVersion).ThenInclude(x => x.AQLs)
                                       .Include(x => x.FourPointsSystem).ThenInclude(x => x.FourPointsSystemDetails)
                                       .Include(x => x.OneHundredPointSystem).ThenInclude(x => x.OneHundredPointSystemDetails)
                                       .Include(x => x.QCDefinitionDefects).ThenInclude(y => y.QCDefect)
                                       .Include(x => x.Conversion)
                                       .Include(x=>x.QCType)
                                       .FirstOrDefaultAsync(x => x.Code == code);
        }
        public async Task<QCDefinition> GetQCDefinitionWithIncludeById(int id)
        {
            return await _qcDefinitions.Include(x => x.AQLVersion).ThenInclude(x => x.AQLs)
                                       .Include(x => x.FourPointsSystem).ThenInclude(x => x.FourPointsSystemDetails)
                                       .Include(x => x.OneHundredPointSystem).ThenInclude(x => x.OneHundredPointSystemDetails)
                                       .Include(x => x.QCDefinitionDefects).ThenInclude(y => y.QCDefect)
                                       .Include(x => x.Conversion)
                                       .Include(x => x.QCType)
                                       .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<QCType> GetQCTypeByQCDefinitionCode(string code)
        {
            return await _qcDefinitions.Include(x => x.QCType).FirstOrDefaultAsync(x => x.Code == code).Select(x => x.QCType);
        }
        public async Task UpdateQCDefinitionsync(QCDefinition qcDefinition, ICollection<QCDefinitionDefect> deletedQCDefinitionDefects, ICollection<QCDefinitionDefect> insertedQCDefinitionDefect)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _qcQCDefinitionDefects.RemoveRange(deletedQCDefinitionDefects);
                _qcQCDefinitionDefects.AddRange(insertedQCDefinitionDefect);
                _qcDefinitions.Update(qcDefinition);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }
    }
}
