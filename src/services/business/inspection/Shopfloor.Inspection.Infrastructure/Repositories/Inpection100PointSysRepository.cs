using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class Inpection100PointSysRepository : GenericRepositoryAsync<Inpection100PointSys>, IInpection100PointSysRepository
    {
        private readonly DbSet<Inpection100PointSys> _inpection100PointSyss;
        private readonly DbSet<InspectionDefectCapturing100PointSys> _inpectionDefectCapturing100PointSyss;
        private readonly DbSet<InspectionDefectError100PointSys> _inpectionDefectError100PointSys;
        public Inpection100PointSysRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _inpection100PointSyss = _dbContext.Set<Inpection100PointSys>();
            _inpectionDefectCapturing100PointSyss = _dbContext.Set<InspectionDefectCapturing100PointSys>();
            _inpectionDefectError100PointSys = _dbContext.Set<InspectionDefectError100PointSys>();
        }
        public async Task<Inpection100PointSys> GetInpection100PointSysWithDetaiḷ(int id)
        {
            return await _inpection100PointSyss.Include(x => x.QCRequestArticle).ThenInclude(x => x.QCRequest)
                                     .Include(x => x.InspectionDefectCapturing100PointSyss).ThenInclude(z => z.InspectionDefectError100PointSyss)
                                     .Include(x => x.Attachments)
                                     .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateInspection100PointSysAsync(Inpection100PointSys inspection100PointSys, IEnumerable<InspectionDefectCapturing100PointSys> inspectionDefectCapturing100PointSyss,
             IEnumerable<InspectionDefectError100PointSys> inspectionDefectError100PointSys)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _inpectionDefectError100PointSys.UpdateRange(inspectionDefectError100PointSys);
                _inpectionDefectCapturing100PointSyss.UpdateRange(inspectionDefectCapturing100PointSyss);
                _inpection100PointSyss.Update(inspection100PointSys);
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
