using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
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

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<ProductGroup>().AnyAsync(x => x.Id == id);
        }

        public async Task<ProductGroup> GetProductGroupByIdAsync(int id)
        {
            return await _productGroups
                .Include(x => x.MaterialTypeMapProductGroups)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetProductGroupPagedResponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<ProductGroup>().Include(x => x.MaterialTypeMapProductGroups).ThenInclude(x => x.MaterialType)
                .Include(x => x.Category).AsSingleQuery().Filter(parameter);
            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                .OrderBy(parameter.OrderBy)
                .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                .Paged(parameter.PageSize, parameter.PageNumber)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return response;
        }

        public async Task UpdateProductGroupAsync(ProductGroup entity, BaseUpdateEntity<MaterialTypeMapProductGroup> materialTypeMapProductGroups)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _dbContext.Set<MaterialTypeMapProductGroup>().RemoveRange(materialTypeMapProductGroups.LstDataDelete);
                _dbContext.Set<MaterialTypeMapProductGroup>().UpdateRange(materialTypeMapProductGroups.LstDataUpdate);
                _dbContext.Set<MaterialTypeMapProductGroup>().AddRange(materialTypeMapProductGroups.LstDataAdd);
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
