using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;
using Shopfloor.Production.Infrastructure.Contexts;

namespace Shopfloor.Production.Infrastructure.Repositories
{
    public class ProductionOutputRepository : GenericRepositoryAsync<ProductionOutput>, IProductionOutputRepository
    {
        private readonly DbSet<ProductionOutput> _productionOutputs;
        private readonly DbSet<InspectionBySize> _inspectionBySizes;
        private readonly DbSet<Measurement> _measurements;
        private readonly DbSet<DefectCapturing> _defectCapturings;
        private readonly DbSet<DefectCapturing4Points> _defectCapturing4Points;
        private readonly DbSet<DefectCapturing100Points> _defectCapturing100Points;
        public ProductionOutputRepository(ProductionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _productionOutputs = dbContext.Set<ProductionOutput>();
            _inspectionBySizes = dbContext.Set<InspectionBySize>();
            _measurements = dbContext.Set<Measurement>();
            _defectCapturings = dbContext.Set<DefectCapturing>();
            _defectCapturing4Points = dbContext.Set<DefectCapturing4Points>();
            _defectCapturing100Points = dbContext.Set<DefectCapturing100Points>();
        }

        public override async Task<ProductionOutput> AddAsync(ProductionOutput entity)
        {
            entity.Code = new Guid().ToString();
            await _productionOutputs.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ProductionOutput> GetDeepByIdAsync(int id)
        {
            return await _productionOutputs
                .Include(x => x.InspectionBySizes)
                .Include(x => x.DefectCapturings)
                .Include(x => x.DefectCapturing4Points)
                .Include(x => x.DefectCapturing100Points)
                .Include(x => x.DefectCapturingStandards)
                .Include(x => x.Measurements)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductionOutput> GetDeepByCodeAsync(string code)
        {
            return await _productionOutputs
                .Include(x => x.InspectionBySizes)
                .Include(x => x.DefectCapturings)
                .Include(x => x.Measurements)
                .FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task UpdateProductionOuputAsync(ProductionOutput productionOutput, IEnumerable<InspectionBySize> inspectionBySizes,
            IEnumerable<Measurement> measurements, IEnumerable<DefectCapturing> defectCapturings, IEnumerable<DefectCapturing4Points> defectCapturing4Points, IEnumerable<DefectCapturing100Points> defectCapturing100Points)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _defectCapturings.UpdateRange(defectCapturings);
                _defectCapturing4Points.UpdateRange(defectCapturing4Points);
                _defectCapturing100Points.UpdateRange(defectCapturing100Points);
                _inspectionBySizes.UpdateRange(inspectionBySizes);
                _measurements.UpdateRange(measurements);

                _productionOutputs.Update(productionOutput);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<ICollection<ProductionOutput>> GetByIdsAsync(int[] ids)
        {
            return await _productionOutputs.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
