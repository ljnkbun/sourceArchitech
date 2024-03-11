using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class InspectionRepository : GenericRepositoryAsync<Shopfloor.Inspection.Domain.Entities.Inspection>, IInspectionRepository
    {
        private readonly DbSet<Inspection.Domain.Entities.Inspection> _inspections;
        private readonly DbSet<InspectionDefectCapturing> _inspectionDefectCapturings;
        private readonly DbSet<InspectionBySize> _inspectionBySizes;
        private readonly DbSet<InspectionMesurement> _inspectionMesurements;
        public InspectionRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _inspections = _dbContext.Set<Inspection.Domain.Entities.Inspection>();
            _inspectionDefectCapturings = _dbContext.Set<InspectionDefectCapturing>();
            _inspectionBySizes = _dbContext.Set<InspectionBySize>();
            _inspectionMesurements = _dbContext.Set<InspectionMesurement>();
        }
        public async Task<bool> CheckExistInspectionByQCRequestArticleIIdAsync(int id)
        {
            return await _inspections.FirstOrDefaultAsync(x => x.QCRequestArticleId == id) != null;
        }
        public async Task<Inspection.Domain.Entities.Inspection> GetInspectionWithDetaiḷ(int id)
        {
            return await _inspections.Include(x => x.QCRequestArticle).ThenInclude(x => x.QCRequest)
                                     .Include(x => x.InspectionBySizes)
                                     .Include(x => x.InspectionDefectCapturings)
                                     .Include(x => x.InspectionMesurements)
                                     .Include(x => x.Attachments)
                                     .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateInspectionAsync(Inspection.Domain.Entities.Inspection inspection, IEnumerable<InspectionDefectCapturing> inspectionDefectCapturings,
             IEnumerable<InspectionBySize> inspectionBySizes, IEnumerable<InspectionMesurement> inspectionMesurements)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _inspectionDefectCapturings.UpdateRange(inspectionDefectCapturings);
                _inspectionBySizes.UpdateRange(inspectionBySizes);
                _inspectionMesurements.UpdateRange(inspectionMesurements);
                _inspections.Update(inspection);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }
        public async Task<Inspection.Domain.Entities.Inspection> GetInspectionByIdAsync(int id)
        {
            return await _inspections.Include(x => x.InspectionDefectCapturings)
                                     .Include(x => x.InspectionMesurements)
                                     .Include(x => x.InspectionBySizes)
                                     .Include(x => x.Attachments).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
