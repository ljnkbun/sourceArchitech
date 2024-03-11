using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class Inpection4PointSysRepository : GenericRepositoryAsync<Inpection4PointSys>, IInpection4PointSysRepository
    {
        private readonly DbSet<Inpection4PointSys> _inpection4PointSyss;
        private readonly DbSet<InspectionDefectCapturing4PointSys> _inpectionDefectCapturing4PointSyss;
        private readonly DbSet<InspectionDefectError4PointSys> _inpectionDefectError4PointSys;
        public Inpection4PointSysRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _inpection4PointSyss = _dbContext.Set<Inpection4PointSys>();
            _inpectionDefectCapturing4PointSyss = _dbContext.Set<InspectionDefectCapturing4PointSys>();
            _inpectionDefectError4PointSys = _dbContext.Set<InspectionDefectError4PointSys>();
        }
        public async Task<Inpection4PointSys> GetInpection4PointSysWithDetaiḷ(int id)
        {
            return await _inpection4PointSyss.Include(x => x.QCRequestArticle).ThenInclude(x => x.QCRequest)
                                     .Include(x => x.InspectionDefectCapturing4PointSyss).ThenInclude(z => z.InspectionDefectError4PointSyss)
                                     .Include(x => x.Attachments)
                                     .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateInspection4PointSysAsync(Inpection4PointSys inspection4PointSys, IEnumerable<InspectionDefectCapturing4PointSys> inspectionDefectCapturing4PointSyss,
             IEnumerable<InspectionDefectError4PointSys> inspectionDefectError4PointSys)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _inpectionDefectError4PointSys.UpdateRange(inspectionDefectError4PointSys);
                _inpectionDefectCapturing4PointSyss.UpdateRange(inspectionDefectCapturing4PointSyss);
                _inpection4PointSyss.Update(inspection4PointSys);
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
