using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class MaterialTypeRepository : MasterRepositoryAsync<MaterialType>, IMaterialTypeRepository
    {
        private readonly DbSet<MaterialType> _materialTypes;
        private readonly DbSet<CategoryMapMaterialType> _categoryMapMaterialTypes;
        public MaterialTypeRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _materialTypes = _dbContext.Set<MaterialType>();
            _categoryMapMaterialTypes = _dbContext.Set<CategoryMapMaterialType>();
        }
        public async Task<MaterialType> GetMaterialTypeByIdAsync(int id)
        {
            return await _materialTypes
                .Include(x => x.CategoryMapMaterialTypes)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateMaterialTypeAsync(MaterialType entity, IEnumerable<CategoryMapMaterialType> categoryMapMaterialTypes)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _categoryMapMaterialTypes.UpdateRange(categoryMapMaterialTypes);
                _materialTypes.Update(entity);

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
