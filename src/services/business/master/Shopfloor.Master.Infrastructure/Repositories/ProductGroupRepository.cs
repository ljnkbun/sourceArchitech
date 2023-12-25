using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class ProductGroupRepository : MasterRepositoryAsync<ProductGroup>, IProductGroupRepository
    {
        private readonly DbSet<ProductGroup> _productGroups;
        private readonly DbSet<MaterialTypeMapProductGroup> _materialTypeMapProductGroups;
        public ProductGroupRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _productGroups = _dbContext.Set<ProductGroup>();
            _materialTypeMapProductGroups = _dbContext.Set<MaterialTypeMapProductGroup>();
        }

        public async Task<ProductGroup> GetProductGroupByIdAsync(int id)
        {
            return await _productGroups
                .Include(x => x.MaterialTypeMapProductGroups)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateProductGroupAsync(ProductGroup entity, IEnumerable<MaterialTypeMapProductGroup> materialTypeMapProductGroups)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _materialTypeMapProductGroups.UpdateRange(materialTypeMapProductGroups);
                _productGroups.Update(entity);

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
